set [r3 00_03] //r3 = 3
set [r4 00_72] //r4 = 'r'
set [r5 00_70] //r5 = 'p'
set [r6 00_73] //r6 = 's'
set [r7 00_01] //r7 = rock
set [r8 00_02] //r8 = paper
set [r9 00_03] //r9 = scissors
set [rA 00_77] //rA = 'w'
set [rB 00_6C] //rB = 'l'
set [rC 00_74] //rC = 't'
set [rD 00_0A] //rD = '\n'

start:
    load[r1 00_05] //load readCharModified into r1
    tpZ [start r1] //if readCharModified is false, goto start

    load[r1 00_04] //load readChar into r1
    load[r2 00_00] //load random number
    
    mod [r2 r2 r3] //r2 is 0, 1, or 2
    _rock:
        eql [r3 r1 r4] //r3 = r1 == 'r'
        tpZ [paper r3] //if r1 is not rock, goto paper
        rrock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [rpapr r3] //if rand is not rock, goto rpapr
            unld[00_06 r4] //set writeChar to 'r'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rC] //set writeChar to 't'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        rpapr:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [rscis r3] //if rand is not paper, goto rsciss
            unld[00_06 r5] //set writeChar to 'p'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rB] //set writeChar to 'l'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        rscis:
            unld[00_06 r9] //set writeChar to 's'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rA] //set writeChar to 'w'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start

    paper:
        eql [r3 r1 r4] //r3 = r1 == 'r'
        tpZ [sciss r3] //if r1 is not rock, goto paper
        prock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [rpapr r3] //if rand is not rock, goto rpapr
            unld[00_06 r4] //set writeChar to 'r'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rA] //set writeChar to 'w'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        ppaper:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [rsciss r3] //if rand is not paper, goto rsciss
            unld[00_06 r5] //set writeChar to 'p'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rC] //set writeChar to 't'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        psciss:
            unld[00_06 r9] //set writeChar to 's'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rB] //set writeChar to 'l'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start

    sciss:
        srock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [rpapr r3] //if rand is not rock, goto rpapr
            unld[00_06 r4] //set writeChar to 'r'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rB] //set writeChar to 'l'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        spaper:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [rsciss r3] //if rand is not paper, goto rsciss
            unld[00_06 r5] //set writeChar to 'p'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rA] //set writeChar to 'w'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
        ssciss:
            unld[00_06 r9] //set writeChar to 's'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rD] //set writeChar to '\n'
            unld[00_07 r7] //set writeCharMod to 1

            unld[00_06 rC] //set writeChar to 't'
            unld[00_07 r7] //set writeCharMod to 1

            tp  [start   ] //goto start
