set [r8 00_00] 
start:
set [r0 01_90] 
set [r1 00_01] 
set [rA 00_09] 
call[_draw   ]
add [r8 r8 rD]
unld[r1 00_08] 
tp  [start   ]
_draw:
    set [r3 00_00] 
    mov [r4 r3   ] 
    add [r4 r4 rA] 
    drawL:
        stPr[r5 line1] 
        add [r5 r5 r3] 
        ldI [r5 r5   ] 
        uldI[r4 r5   ] 
        add [r3 r3 r1]
        add [r4 r4 r1]  
        eql [rF r3 r0] 
        tpZ [rF drawL] 
    ret [        ] 
$---$
line1: FFFF