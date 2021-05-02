using System;
using System.Text;
using ILLVM.References;
using ILLVM.Types;

/*
 * TODO: Add functionality to retrieve LFunctionType from this LExternal.
 */

namespace ILLVM {
    /// <summary>
    /// Represents external function declaration.
    /// </summary>
    public class LExternal {
        public readonly LFunctionType FnType;
        public readonly string FnIdentifier;

        public LExternal(LFunctionType fnType, string fnIdentifier) {
            FnType = fnType;
            FnIdentifier = fnIdentifier;
        }

        public string Parse() {
            StringBuilder sb = new StringBuilder("declare ");

            sb.Append(FnType.ReturnType.ParseType()).Append(" ");
            sb.Append(FnIdentifier).Append("(");

            for (int i = 0; i < FnType.Parameters.Length; ++i) {
                if (i > 0) {
                    sb.Append(", ");
                }

                sb.Append(FnType.Parameters[i].ParseType());
            }
            if (FnType.HasVararg.HasValue && FnType.HasVararg.Value) {
                sb.Append(", ...");
            }

            sb.Append(")");
            return sb.ToString();
        }
    }
}