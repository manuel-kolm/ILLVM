using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    /// <summary>
    /// Conditions for integral types.
    /// </summary>
    public enum LICondition {
        /// <summary>equal</summary>
        eq,
        /// <summary>not equal</summary>
        ne,
        /// <summary>unsigned greater than</summary>
        ugt,
        /// <summary>unsigned greater or equal</summary>
        uge,
        /// <summary>unsigned less than</summary>
        ult,
        /// <summary>unsigned less or equal</summary>
        ule,
        /// <summary>signed greater than</summary>
        sgt,
        /// <summary>signed greater or equal</summary>
        sge,
        /// <summary>signed less than</summary>
        slt,
        /// <summary>signed less or equal</summary>
        sle
    }

    public static class LIConditionExt {
        public static string Parse(this LICondition self) {
            return self switch {
                LICondition.eq => LKeywords.Eq,
                LICondition.ne => LKeywords.Ne,
                LICondition.ugt => LKeywords.Ugt,
                LICondition.uge => LKeywords.Uge,
                LICondition.ult => LKeywords.Ult,
                LICondition.ule => LKeywords.Ule,
                LICondition.sgt => LKeywords.Sgt,
                LICondition.sge => LKeywords.Sge,
                LICondition.slt => LKeywords.Slt,
                LICondition.sle => LKeywords.Sle,
                _ => throw new NotImplementedException("Unknown condition."),
            };
        }
    }
}
