using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    public enum LFastMathFlags {
        nnan,
        ninf,
        arcp,
        contract,
        afn,
        reassoc,
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
