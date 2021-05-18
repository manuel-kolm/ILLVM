using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    public enum LFastMathFlags {
        /// <summary>
        /// No NaNs - Allow optimizations to assume the arguments and result are not NaN.
        /// If an argument is a nan, or the result would be a nan, it produces a poison value instead.
        /// </summary>
        nnan,
        /// <summary>
        /// No Infs - Allow optimizations to assume the arguments and result are not +/-Inf.
        /// If an argument is +/-Inf, or the result would be +/-Inf, it produces a poison value instead.
        /// </summary>
        ninf,
        /// <summary>
        /// No Signed Zeros - Allow optimizations to treat the sign of a zero argument or result as insignificant.
        /// This does not imply that -0.0 is poison and/or guaranteed to not exist in the operation.
        /// </summary>
        arcp,
        /// <summary>
        /// Allow Reciprocal - Allow optimizations to use the reciprocal of an argument rather than perform division.
        /// </summary>
        contract,
        /// <summary>
        /// Allow floating-point contraction (e.g. fusing a multiply followed by an addition into a fused multiply-and-add).
        /// This does not enable reassociating to form arbitrary contractions.
        /// For example, (a*b) + (c*d) + e can not be transformed into (a*b) + ((c*d) + e) to create two fma operations.
        /// </summary>
        afn,
        /// <summary>
        /// Approximate functions - Allow substitution of approximate calculations for functions (sin, log, sqrt, etc).
        /// See floating-point intrinsic definitions for places where this can apply to LLVM’s intrinsic math functions.
        /// </summary>
        reassoc,
        /// <summary>
        /// This flag implies all of the others.
        /// </summary>
        fast
    }
    
    public static class LFastMathFlagsExt {
        public static string Parse(this LFastMathFlags self) {
            return self switch {
                LFastMathFlags.nnan => "nnan",
                LFastMathFlags.ninf => "ninf",
                LFastMathFlags.arcp => "arcp",
                LFastMathFlags.contract => "contract",
                LFastMathFlags.afn => "afn",
                LFastMathFlags.reassoc => "reassoc",
                LFastMathFlags.fast => "fast",
                _ => throw new NotImplementedException("Unknown fast math flag.")
            };
        }
    }
}
