using System.Text;
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

            if (FnType.ReturnType.IsValue()) {
                sb.Append(((LValueRef)FnType.ReturnType).Identifier).Append(" ");
            } else {
                sb.Append(((LPointerRef)FnType.ReturnType).Identifier).Append(" ");
            }

            sb.Append(" = call ");
            sb.Append(FnType.Parse()).Append(" ");
            sb.Append(FnIdentifier).Append("(");

            for (int i = 0; i < FnType.Parameters.Length; ++i) {
                if (i > 0) {
                    sb.Append(", ");
                }
                sb.Append(FnType.Parameters[i].ParseType()).Append(" ");
                sb.Append(FnType.Parameters[i].IsValue() ? ((LValueRef)FnType.Parameters[i]).ValueOrIdentifier : ((LPointerRef)FnType.Parameters[i]).Identifier);
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}