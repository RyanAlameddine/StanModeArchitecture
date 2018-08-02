using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMA;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SMAAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(args[0]);
            #region assembler
            data = Regex.Replace(data, "\r", "\n");
            data = Regex.Replace(data, @"\n\ *\n", "\n");
            data = Regex.Replace(data, @"\n\ *\n", "\n");
            byte[] bytes;
            Match uscore = Regex.Match(data, "[0-9A-F]{2}_[0-9A-F]{2}");
            while(uscore.Length > 0)
            {
                data = data.Remove(uscore.Index + 2, 1);
                uscore = Regex.Match(data, "[0-9A-F]{2}_[0-9A-F]{2}");
            }

            #region progMem
            string[] progMemSplit = Regex.Split(data, @"^\$---\$", RegexOptions.Multiline);
            string progMem = "";
            if (progMemSplit.Length == 2)
            {
                progMem = progMemSplit[1];
            }
            else if (progMemSplit.Length > 2)
            {
                throw new OverflowException("Too many program memory markers $---$");
            }

            MatchCollection strings = Regex.Matches(progMem, "\".*\"");
            foreach(Match str in strings)
            {
                string stringToConvert = str.Value;
                //stringToConvert = stringToConvert.Remove(stringToConvert.Length - 1, 1).Remove(0, 1);
                stringToConvert = JsonConvert.DeserializeObject<string>(stringToConvert);
                string output = "";
                for(int i = 0; i < stringToConvert.Length; i++)
                {
                    output += ((ushort)stringToConvert[i]).ToString("X").PadLeft(4, '0') + ' ';
                }
                output.Remove(output.Length - 1);
                progMem = progMem.Replace(str.Value, output);
            }

            data = progMemSplit[0];
            progMem = "FFFF FFFF" + progMem;

            MatchCollection chars = Regex.Matches(progMem, "'.*\'");
            foreach (Match chr in chars)
            {
                string charToConvert = chr.Value;
                //stringToConvert = stringToConvert.Remove(stringToConvert.Length - 1, 1).Remove(0, 1);
                charToConvert = JsonConvert.DeserializeObject<string>(charToConvert);

                string output = ((ushort)charToConvert[0]).ToString("X").PadLeft(4, '0') + ' ';
                if (charToConvert.Length > 1) throw new IndexOutOfRangeException("' ' refers to a char, not a string. Please do not use ' ' around a value with more than one char.");
                output.Remove(output.Length - 1);
                progMem = progMem.Replace(chr.Value, output);
            }

            #endregion progMem

            MatchCollection labels = Regex.Matches(data, ".*:");
            Dictionary<string, string> lbls = new Dictionary<string, string>();
            foreach (Match match in labels)
            {
                lbls.Add(match.Value, (data.Take(match.Index).Count(c => c == '\n') + 1).ToString("X").PadLeft(4, '0'));
            }
            foreach(Match match in labels)
            {
                data = Regex.Replace(data, @"(?<=(\[| ))" + match.Value.Remove(match.Value.Length - 1).Replace(" ", "") + @"(?=(\]| ))", lbls[match.Value]);
                data = data.Replace(match.Value, "noOp[        ] ");
            }

            MatchCollection progLabels = Regex.Matches(progMem, ".*: ");
            int lOffset = 0;
            int dataLineCount = data.Take(data.Length).Count(c => c == '\n');
            foreach (Match match in progLabels)
            {
                int shortCount = 0;
                progMem = Regex.Replace(progMem, match.Value, "");
                int endChar = match.Index - lOffset;
                lOffset += match.Length;
                for (int i = 0; i < endChar; i++)
                {
                    if(progMem[i] == ' ' || progMem[i] == '\n')
                    {
                        shortCount++;
                    }
                }
                string text = data;
                data = Regex.Replace(data, @"(?<=(\[| ))" + match.Value.Remove(match.Value.Length - 2).Replace(" ", "") + @"(?=(\]| ))", (shortCount + dataLineCount*2 + 1).ToString("X").PadLeft(4, '0'));
            }

            MatchCollection progEndian = Regex.Matches(progMem, "[0-9A-F]{4}");
            foreach (Match match in progEndian)
            {
                string start = match.Value.Substring(2);
                start += match.Value.Substring(0, 2);
                var aStringBuilder = new StringBuilder(progMem);
                aStringBuilder.Remove(match.Index, 4);
                aStringBuilder.Insert(match.Index, start);
                progMem = aStringBuilder.ToString();
            }

            data += progMem;



            foreach (OpCode opCode in Enum.GetValues(typeof(OpCode)))
            {
                data = Regex.Replace(data, "^ *" + opCode.ToString() + "( *)\\[", ((int)opCode).ToString("X").PadLeft(2, '0') + '[', RegexOptions.Multiline);
                
            }
            //data = Regex.Replace(data, @"\(.*\)", "");
            data = Regex.Replace(data, @"//.*", "");
            data = Regex.Replace(data, @"/\*.*\*/", "", RegexOptions.Singleline);
            data = data.Replace(" ", "");

            MatchCollection paramStrings = Regex.Matches(data, @"\[.*\]");

            foreach (Match match in paramStrings)
            {
                string fixedString = match.Value.Remove(match.Value.Length - 1).Remove(0, 1);
                fixedString = '[' + fixedString.PadLeft(6, '0') + ']';

                if (match.Value != fixedString)
                {
                    data = data.Replace(match.Value, fixedString);
                }
            }

            data = data.Replace("[", ""); 
            data = data.Replace("]", ""); 
            data = data.Replace('r', '0'); 
            data = data.Replace("\n", "");
            data = data.Replace("\r", ""); 
            
            bytes = new byte[data.Length / 2];
            for(int i = 0; i < data.Length; )
            {
                string sByte = data[i] + "" + data[i + 1];
                i += 2;
                bytes[i / 2 - 1] = byte.Parse(sByte, System.Globalization.NumberStyles.HexNumber);
            }
            File.WriteAllBytes(args[1], bytes);
            #endregion

            #region disassembler

            StringBuilder sb = new StringBuilder();
            byte[] bytesToDisassemble = File.ReadAllBytes(args[1]);
            bool progMemActive = false;
            for(int i = 0; i < bytesToDisassemble.Length/2; i+=2)
            {
                Span<byte> paramSpan = bytesToDisassemble;
                if (paramSpan[i * 2] == 0xFF && paramSpan[i * 2 + 1] == 0xFF && paramSpan[i * 2 + 2] == 0xFF && paramSpan[i * 2 + 3] == 0xFF)
                {
                    progMemActive = true;
                    sb.Append("$---$\n");
                    continue;
                }
                if (progMemActive)
                {
                    sb.Append(paramSpan[i * 2].ToString("X").PadLeft(2, '0'));
                    sb.Append('_');
                    sb.Append(paramSpan[i * 2 + 1].ToString("X").PadLeft(2, '0'));
                    sb.Append(' ');
                    i--;
                    continue;
                }
                paramSpan = paramSpan.Slice(i * 2, 4);
                string op = Enum.GetName(typeof(OpCode), paramSpan[0]);
                dynamic des = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "opCodes.json")));
                string paramString = "[";
                JArray Jparams = des[op]["params"];
                int offset = 1;
                for(int j = 0; j < Jparams.Count; j++)
                {
                    var param = Jparams[j];
                    if (param["type"].Value<string>() == "Register") { paramString += 'r' + paramSpan[j + offset].ToString("X") + ' '; }
                    else
                    {
                        paramString += paramSpan[j + offset].ToString("X").PadLeft(2, '0') + '_' + paramSpan[j + offset + 1].ToString("X").PadLeft(2, '0') + ' ';
                        offset++;
                    }
                }
                if (Jparams.Count > 0)
                {
                    paramString = paramString.Remove(paramString.Length - 1);
                }
                paramString = paramString.PadRight(9) + ']';
                sb.Append(op.PadRight(4));
                sb.Append(paramString);
                sb.Append('\n');
            }

            File.WriteAllText(args[2], sb.ToString());
            #endregion
        }
    }
}
