using System;
using System.Collections.Generic;
using System.Text;

namespace SMA
{
    public enum OpCode
    {
        noOp = 0x0,

        add  = 0x2,
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
        mov

    }
}
