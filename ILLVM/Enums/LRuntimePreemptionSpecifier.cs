using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    /// <summary>
    /// Global variables, functions and aliases may have an optional runtime preemption specifier.
    /// If a preemption specifier isn’t given explicitly, then a symbol is assumed to be dso_preemptable.
    /// </summary>
    public enum LRuntimePreemptionSpecifier {
        /// <summary>
        /// Indicates that the function or variable may be replaced by a symbol from outside the linkage unit at runtime.
        /// </summary>
        dso_preemptable,
        /// <summary>
        /// The compiler may assume that a function or variable marked as dso_local will resolve to a symbol within the same linkage unit.
        /// Direct access will be generated even if the definition is not within this compilation unit.
        /// </summary>
        dso_local
    }

    public static class LLRuntimePreemptionSpecifierExt {
        public static string Parse(this LRuntimePreemptionSpecifier self) {
            return self switch {
                LRuntimePreemptionSpecifier.dso_preemptable => LKeywords.DsoPreemptable,
                LRuntimePreemptionSpecifier.dso_local => LKeywords.DsoLocal,
                _ => throw new NotImplementedException("Unknown runtime preemption specifier.")
            };
        }
    }
}
