xor [r1 r1 r1] //r1 = 0                      0F 01 01 01
set [r4 00_64] //r4 = 100                    25 04 00 64
set [r5 00_01] //r5 = 1                      25 05 00 01
set [r8 01_00] //r8 = 256                    25 08 01 00
load[r2 00_00] //r2 = random                 20 02 00 00
add [r1 r1 r5] //r1 = r1 + r5                01 01 01 05
unld<r8 r2   ] //store r2 into *r8           22 00 08 02
add [r8 r8 r5] //add 1 to r8                 02 08 08 05
eql [r3 r1 r4] //r3 = r1 == 64               10 03 01 04
tpZ [00_05 r3] //if(r3) goto 4               1E 00 04 03
set [r9 01_00] //set r9 to 256               25 09 01 00
sub [r8 r8 r5] //r8--                        03 08 08 05
set [r1 00_14] //r1 = 20                     26 01 00 14
xor [r6 r6 r6] //r6 = 0                      0F 06 06 06
xor [r4 r4 r4] //r4 = 0                      0F 04 04 04
set [rA 00_64] //rA = 100                    26 0A 00 64
load<r2 r8   ] //r2 = *r8                    21 00 02 08
mov [r8 r2   ] //r8 = r2                     27 00 08 02
mod [r8 r8 rA] //r8 = r8 % r8                06 08 08 0A
add [r8 r8 r9] //r8 = r8 + 256               02 08 08 09
add [r4 r4 r2] //r4 = r4 + r2                01 04 04 02
sub [r1 r1 r5] //r1 = r1 - 1                 02 01 01 05
eql [r3 r1 r6] //r3 = r1 == 0                10 03 01 06
tpZ [00_11 r3] //if(r3) goto 17              1F 00 11 03

unld[00_02 r4] //writeInt = r4               21 00 02 04
unld[00_03 r5] //writeIntModified = 1        21 00 03 05