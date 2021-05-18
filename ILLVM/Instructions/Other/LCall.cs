using System.Text;
using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using ILLVM.Types;

namespace ILLVM.Instructions.Other {
    public class LCall : ILBaseInstr {
        public readonly LFunctionType FnType;
        public readonly string FnIdentifier;

        public LCall(LFunctionType fnType, string fnIdentifier) {
            FnType = fnType;
            FnIdentifier = fnIdentifier;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder();
            sb.Append(LRefHelper.GetIdentifierOf(FnType.ReturnType)).Append(" ");
            sb.Append(" = ").Append(LKeywords.Call);
            sb.Append(FnType.Parse()).Append(" ");
            sb.Append(FnIdentifier).Append("(");

            for (int i = 0; i < FnType.Parameters.Length; ++i) {
                if (i > 0) {
                    sb.Append(", ");
                }
                sb.Append(FnType.Parameters[i].ParseType()).Append(" ");
                sb.Append(LRefHelper.GetValueOrIdentifierOf(FnType.Parameters[i]));
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}