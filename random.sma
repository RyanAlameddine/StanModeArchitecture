/*
    Sum 100 random numbers
*/

xor  [r1 r1 r1] //r1 = 0                      0F 01 01 01
set  [r4 00_64] //r4 = 64                     25 04 00 64
set  [r5 00_01] //r5 = 1                      25 05 00 01
load [r2 00_00] //r2 = random                 20 02 00 00
add  [r1 r1 r5] //r1 = r1 + r5                01 01 01 05
push [r2      ] //push r2                     22 00 00 02
eql  [r3 r1 r4] //r3 = r1 == 64               10 03 01 04
tpZ  [00_04 r3] //if(r3) goto 4               1E 00 04 03

#region Count back down:
xor  [r6 r6 r6] //r6 = 0                      0F 06 06 06
xor  [r4 r4 r4] //r4 = 0                      0F 04 04 04
pop  [r2      ] //r2 = pop                    23 00 00 02
add  [r4 r4 r2] //r4 = r4 + r2                01 04 04 02
sub  [r1 r1 r5] //r1 = r1 - 1                 02 01 01 05
eql  [r3 r1 r6] //r3 = r1 == 0                10 03 01 06
tpZ  [00_0C r3] //if(r3) goto 12              1E 00 0C 03
#endregion

unld [00_02 r4] //writeInt = r4               21 00 02 04
unld [00_03 r5] //writeIntModified = 1        21 00 03 05