set [r1 00_05] //r1 = 5                                     25 01 00 05
push[r1      ] //push 5                                     23 00 00 01
call[facto   ] //call facto                                 30 00 00 09
pop [r3      ] //pop param                                  24 00 00 03
unld[00_02 r1] //writeInt = r1                              22 00 02 01
unld[00_03 r2] //writeIntModified = something not zero :)   22 00 03 02


facto:             /*(int)*/
    set [r2 00_01] //r2 = 1                                 26 02 00 01
    peek[r3 00_01] //r3 = 5,4,3,2,1                         25 03 00 01

    nEql[r5 r1 r2] //r5 = r3 != 1 = true                    14 05 01 02
    tpZ [_end_ r5] //if(r5 == 1){ goto end }                1F 00 17 05
    push[r3      ] //push r3                                23 00 00 03
    sub [r3 r3 r2] //r6 = r6 - 1                            03 03 03 02
    push[r6      ] //push r6                                23 00 00 06
    call[facto   ] //call facto                             30 00 00 09
    pop [r3      ] //pop param                              24 00 00 03
    pop [r3      ] //pop to r3                              24 00 00 03
    mult[r3 r3 r1] //r3 = r3 * r1                           04 03 03 01

    _end_:
        mov [r1 r3   ] //r1 = r3                            27 00 01 03
        ret [        ] //pop, then return r1                31 00 00 00