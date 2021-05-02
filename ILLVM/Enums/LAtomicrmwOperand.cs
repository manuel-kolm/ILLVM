using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    public enum LAtomicrmwOperand {
        /// <summary>*ptr = val</summary>
        xchg,
        /// <summary>*ptr = *ptr + val</summary>
        add,
        /// <summary>*ptr = *ptr - val</summary>
        sub,
        /// <summary>*ptr = *ptr & val</summary>
        and,
        /// <summary>*ptr = ~(*ptr & val)</summary>
        nand,
        /// <summary>*ptr = *ptr | val</summary>
        or,
        /// <summary>*ptr = *ptr ^ val</summary>
        xor,
        /// <summary>*ptr = *ptr > val ? *ptr : val (using a signed comparison)</summary>
        max,
        /// <summary>*ptr = *ptr < val ? *ptr : val (using a signed comparison)</summary>
        min,
        /// <summary>*ptr = *ptr > val ? *ptr : val (using an unsigned comparison)</summary>
        umax,
        /// <summary>*ptr = *ptr < val ? *ptr : val (using an unsigned comparison)</summary>
        umin,
        /// <summary>*ptr = *ptr + val (using floating point arithmetic)</summary>
        fadd,
        /// <summary>*ptr = *ptr - val (using floating point arithmetic)</summary>
        fsub
    }

    public static class LAtomicrmwOperandExt {
        public static string Parse(this LAtomicrmwOperand self) {
            return self switch {
                LAtomicrmwOperand.xchg => LKeywords.Xchg,
                LAtomicrmwOperand.add => LKeywords.Add,
                LAtomicrmwOperand.sub => LKeywords.Sub,
                LAtomicrmwOperand.and => LKeywords.And,
                LAtomicrmwOperand.nand => LKeywords.Nand,
                LAtomicrmwOperand.or => LKeywords.Or,
                LAtomicrmwOperand.xor => LKeywords.Xor,
                LAtomicrmwOperand.max => LKeywords.Max,
                LAtomicrmwOperand.min => LKeywords.Min,
                LAtomicrmwOperand.umax => LKeywords.Umax,
                LAtomicrmwOperand.umin => LKeywords.Umin,
                LAtomicrmwOperand.fadd => LKeywords.Fadd,
                LAtomicrmwOperand.fsub => LKeywords.Fsub,
                _ => throw new NotImplementedException("Unknown operand."),
            };
        }
    }
}
