# StanModeArchitecture
SM Architecture and ISA

Syntax Hightlighter and VSCode extension for SM Architecture can be found here:
https://github.com/RyanAlameddine/SMAVSCode

Quick Summary of op-codes:



OpCode|Operation|Description|Category|Params|Params
| --- | --- | --- | --- | --- | --- |
noOp|No Operator|No operation is performed by this opCode|Other||
add|Add|This operation performs *Destination* = *Source 1* + *Source 2*|Math|Destination|Register
||||Source 1|Register
||||Source 2|Register
sub|Subtract|This operation performs *Destination* = *Source 1* - *Source 2*|Math|Destination|Register
||||Source 1|Register
||||Source 2|Register
mult|Multiply|This operation performs *Destination* = *Source 1* * *Source 2*|Math|Destination|Register
||||Source 1|Register
||||Source 2|Register
div|Divide|This operation performs *Destination* = *Source 1* / *Source 2*|Math|Destination|Register
||||Source 1|Register
||||Source 2|Register
mod|Mod|This operation performs *Destination* = *Source 1* % *Source 2*|Math|Destination|Register
||||Source 1|Register
||||Source 2|Register
rSft|Shift Right|This operation performs *Source* = *Source* >> *Amount*|Math|Source|Register
||||Amount|Short
lSft|Shift Left|This operation performs *Source* = *Source* << *Amount*|Math|Source|Register
||||Amount|Short
not|Not Operator|This operation performs *Source* = ~*Source*|Logic|Source|Register
and|And Operator|This operation performs *Destination* = *Source 1* & *Source 2*|Logic|Destination|Register
||||Source 1|Register
||||Source 2|Register
or|Or Operator|This operation performs *Destination* = *Source 1* | *Source 2*|Logic|Destination|Register
||||Source 1|Register
||||Source 2|Register
xor|Exclusive Or Operator|This operation performs *Destination* = *Source 1* ^ *Source 2*|Logic|Destination|Register
||||Source 1|Register
||||Source 2|Register
eql|Check Equality|This operation performs *Destination* = *Source 1* == *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
grtr|Check Greater Than|This operation performs *Destination* = *Source 1* > *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
less|Check Less Than|This operation performs *Destination* = *Source 1* < *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
nEql|Check InEquality|This operation performs *Destination* = *Source 1* != *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
grtE|Check Greater Than or Equal|This operation performs *Destination* = *Source 1* >= *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
lssE|Check Less Than or Equal|This operation performs *Destination* = *Source 1* <= *Source 2*|Comparison|Destination|Register
||||Source 1|Register
||||Source 2|Register
tp|Teleport|This operation performs jumps to the address *Address*|Flow|Address|Short
tpZ|Teleport if Zero|This operation performs jumps to the address *Address* if *Source* == 0|Flow|Source|Register
||||Address|Short
tpNZ|Teleport if not Zero|This operation performs jumps to the address *Address* if *Source* != 0|Flow|Source|Register
||||Address|Short
load|Load|This operation loads value at *Address* into *Destination*|Memory|Destination|Register
||||Address|Short
unld|Unload|This operation unloads value from *Source* into *Address*|Memory|Source|Register
||||Address|Short
push|Push|This operation pushes *Source* to the stack|Memory|Source|Register
pop|Pop|This operation pops from the stack into *Destination|Memory|Destination|Register
peek|Peek|This operation loads from the stack offset by *Offset* into *Destination*|Memory|Destination|Register
||||Offset|Short
set|Set|This operation sets the register *Destination* to *Value*|Memory|Destination|Register
||||Value|Short
stPr|Set in Program space|This operation sets the register *Destination* to the *Label*'s address relative to Program Space|Memory|Destination|Register
||||Label|Short
mov|Move|This operation copies *Source* to *Destination*|Memory|Destination|Register
||||Source|Register
call|Call|This operation calls a function at address *Address*|CallRet|Address|Short
ret|Return|This operation returns from a function|CallRet||
ldI|Load Indirect|This operation loads value at address *Source* into *Destination*|Indirect|Destination|Register
||||Source|Register
uldI|Unload Indirect|This operation unloads *Source* into value at address *Destination*|Indirect|Destination|Register
||||Source|Register




Full ISA op-code description and ISA conventions can be found here:
https://docs.google.com/spreadsheets/d/1sc8BUHLu5ysgNF8ssG-PJg16butrIkTLEKPQxbujhpc/edit#gid=0
