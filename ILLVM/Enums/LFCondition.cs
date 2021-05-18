using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    /// <summary>
    /// Conditions for floating point types.
    /// </summary>
    public enum LFCondition {
        /// <summary>no comparison, always returns false</summary>
        @false,
        /// <summary>ordered and equal</summary>
        oeq,
        /// <summary>ordered and greater than</summary>
        ogt,
        /// <summary>ordered and greater than or equal</summary>
        oge,
        /// <summary>ordered and less than</summary>
        olt,
        /// <summary>ordered and less than or equal</summary>
        ole,
        /// <summary>ordered and not equal</summary>
        one,
        /// <summary>ordered (no nans)</summary>
        ord,
        /// <summary>unordered or equal</summary>
        ueq,
        /// <summary>unordered or greater than</summary>
        ugt,
        /// <summary>unordered or greater than or equal</summary>
        uge,
        /// <summary>unordered or less than</summary>
        ult,
        /// <summary>unordered or less than or equal</summary>
        ule,
        /// <summary>unordered or not equal</summary>
        une,
        /// <summary>unordered (either nans)</summary>
        uno,
        /// <summary>no comparison, always returns true</summary>
        @true
    }

    public static class LFConditionExt {
        public static string Parse(this LFCondition self) {
            return self switch {
                LFCondition.@false => LKeywords.False,
                LFCondition.oeq => LKeywords.Oeq,
                LFCondition.ogt => LKeywords.Ogt,
                LFCondition.oge => LKeywords.Oge,
                LFCondition.olt => LKeywords.Olt,
                LFCondition.ole => LKeywords.Ole,
                LFCondition.one => LKeywords.One,
                LFCondition.ord => LKeywords.Ord,
                LFCondition.ueq => LKeywords.Ueq,
                LFCondition.ugt => LKeywords.Ugt,
                LFCondition.uge => LKeywords.Uge,
                LFCondition.ult => LKeywords.Ult,
                LFCondition.ule => LKeywords.Ule,
                LFCondition.une => LKeywords.Une,
                LFCondition.uno => LKeywords.Uno,
                LFCondition.@true => LKeywords.True,
                _ => throw new NotImplementedException("Unknown condition."),
            };
        }
    }
}
