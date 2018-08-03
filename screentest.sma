set [r8 00_00] 
set [rD 00_0A] 
set [r2 00_02] 
start:
set [r0 01_90] 
set [r1 00_01] 
set [rA 00_09] 
set [rB 00_02] 
call[_draw   ]
add [r8 r8 rD] //eql [r9 r8 rD] 
unld[r1 00_08] 
tp  [start   ] //unld[r1 00_00]
_draw:
    set [r3 00_00] 
    mov [r5 r3   ] 
    mov [r4 r3   ] 
    add [r4 r4 rA] 
    drawL:
        mod [rE r5 r2] 
        uldI[r4 r3   ] 
        tpZ [rE noPlu] 
        sub [r3 r3 r1] 
        noPlu:
        add [r3 r3 r8] 
        uldI[r4 r3   ] 
        sub [r3 r3 r8] 
        add [r3 r3 r1]
        add [r5 r5 r1] 
        add [r4 r4 r1]  
        eql [rF r3 r0] 
        tpZ [rF drawL] 
    ret [        ] 
$---$
black: 0010
dBlue: 0004