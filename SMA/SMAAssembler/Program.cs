using SMA;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SMAAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(args[0]);
            data = Regex.Replace(data, @"/n\ *(/r*)/n", "/n");
            byte[] bytes;
            Match uscore = Regex.Match(data, "[0-9A-F]{2}_[0-9A-F]{2}");
            while(uscore.Length > 0)
            {   
                char[] chars = data.ToCharArray();
                chars[uscore.Index + 2] = ' ';
                data = new string(chars);
                uscore = Regex.Match(data, "[0-9A-F]{2}_[0-9A-F]{2}");
            }

            MatchCollection labels = Regex.Matches(data, ".*:");
            int index = 0;
            foreach(Match match in labels)
            {
                data = data.Replace(match.Value, "00[00 00 00]");
                data = Regex.Replace(data, match.Value.Remove(match.Value.Length - 1), (data.Take(match.Index).Count(c => c == '\n') + 1).ToString("X").PadLeft(4, '0'));
                index++;

            }
            foreach(OpCode opCode in Enum.GetValues(typeof(OpCode)))
            {
                data = Regex.Replace(data, @"^ *" + opCode.ToString(), ((int)opCode).ToString("X").PadLeft(2, '0'), RegexOptions.Multiline);
            }
            data = Regex.Replace(data, @"\(.*\)", "");
            data = Regex.Replace(data, @"//.*", "");
            data = Regex.Replace(data, @"/\*.*\*/", "", RegexOptions.Singleline);
            data = data.Replace('r', '0');
            data = data.Replace(" ", "");

            MatchCollection paramStrings = Regex.Matches(data, @"\[.*\]");

            foreach (Match match in paramStrings)
            {
                string fixedString = match.Value.Remove(match.Value.Length - 1).Remove(0, 1);
                fixedString = '[' + uint.Parse(fixedString, System.Globalization.NumberStyles.HexNumber).ToString("X").PadLeft(6, '0') + ']';

                if (match.Value != fixedString)
                {
                    data = data.Replace(match.Value, fixedString);
                }
            }

            data = data.Replace("\n", "");
            data = data.Replace("\r", "");

            data = data.Replace("[", "");
            data = data.Replace("]", "");

            bytes = new byte[data.Length / 2];
            for(int i = 0; i < data.Length; )
            {
                string sByte = data[i] + "" + data[i + 1];
                i += 2;
                bytes[i / 2 - 1] = byte.Parse(sByte, System.Globalization.NumberStyles.HexNumber);
            }
            File.WriteAllBytes(args[1], bytes);
        }
    }
}
