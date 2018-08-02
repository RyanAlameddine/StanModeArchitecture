set [r8 00_00] 
set [rD 00_50] 
start:
set [r0 01_90] 
set [r1 00_01] 
set [rA 00_09] 
set [rB 00_02] 
call[_draw   ]
add [r8 r8 r1] 
eql [r9 r8 rD] 
unld[r1 00_08] 
wait[00_02   ]
tpZ [r9 start] 
unld[r1 00_00]
_draw:
    set [r3 00_00] 
    mov [r4 r3   ] 
    add [r4 r4 rA] 
    drawL:
        mov [r5 r3   ] //stPr[r5 dBlue] //ldI [r5 r5   ]
        add [r5 r5 r8] 
        uldI[r4 r5   ] 
        mod [r6 r3 rB]
        eql [r6 r6 r1] 
        tpZ [r6 ntClr]
        add [r3 r3 r8] 
        uldI[r4 r3   ] 
        sub [r3 r3 r8] 
        ntClr:
        add [r3 r3 r1]
        add [r4 r4 r1]  
        eql [rF r3 r0] 
        tpZ [rF drawL] 
    ret [        ] 
$---$
black: 0010
dBlue: 0004