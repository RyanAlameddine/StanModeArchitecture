﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SMA
{
    public enum OpCode
    {
        noOp = 0x0,

        add  = 0x1,
        sub,
        mult,
        div,
        mod,

        rSft = 0xA,
        lSft,
        not,
        and,
        or,
        xor,

        eql = 0x10,
        grtr,
        less,
        nEql,
        grtE,
        lssE,

        tp = 0x1A,
        tpZ,
        tpNZ,

        load = 0x20,
        unld,
        push,
        pop,
        peek,
        set,
        mov,
        stPr,

        call = 0x30,
        ret,
        wait,

        ldI = 0x40,
        uldI
    }
}
