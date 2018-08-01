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
    tpZ [r1 start] //if readCharModified is false, goto start

    load[r1 00_04] //load readChar into r1
    load[r2 00_00] //load random number
    
    mod [r2 r2 r3] //r2 is 0, 1, or 2
    _rock:
        eql [r3 r1 r4] //r3 = r1 == 'r'
        tpZ [r3 paper] //if r1 is not rock, goto paper
        rrock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [r3 rpapr] //if rand is not rock, goto rpapr
            unld[r4 00_06] //set writeChar to 'r'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1
            
            unld[rC 00_06] //set writeChar to 't'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        rpapr:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [r3 rscis] //if rand is not paper, goto rsciss
            unld[r5 00_06] //set writeChar to 'p'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rB 00_06] //set writeChar to 'l'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        rscis:
            unld[r9 00_06] //set writeChar to 's'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rA 00_06] //set writeChar to 'w'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start

    paper:
        eql [r3 r1 r4] //r3 = r1 == 'r'
        tpZ [sciss r3] //if r1 is not rock, goto paper
        prock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [r3 ppapr] //if rand is not rock, goto rpapr
            unld[r4 00_06] //set writeChar to 'r'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rA 00_06] //set writeChar to 'w'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        ppapr:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [r3 pscis] //if rand is not paper, goto rsciss
            unld[r5 00_06] //set writeChar to 'p'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rC 00_06] //set writeChar to 't'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        pscis:
            unld[r9 00_06] //set writeChar to 's'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rB 00_06] //set writeChar to 'l'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start

    sciss:
        srock:
            eql [r3 r2 r7] //r3 = rand != rock
            tpZ [r3 spapr] //if rand is not rock, goto rpapr
            unld[r4 00_06] //set writeChar to 'r'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rB 00_06] //set writeChar to 'l'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        spapr:
            eql [r3 r2 r8] //r3 = rand != paper
            tpZ [r3 sscis] //if rand is not paper, goto rsciss
            unld[r5 00_06] //set writeChar to 'p'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rA 00_06] //set writeChar to 'w'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start
        sscis:
            unld[r9 00_06] //set writeChar to 's'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rD 00_06] //set writeChar to '\n'
            unld[r7 00_07] //set writeCharMod to 1

            unld[rC 00_06] //set writeChar to 't'
            unld[r7 00_07] //set writeCharMod to 1

            tp  [start   ] //goto start