using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Unary {
    public class LFneg : ILBaseInstr {
        public LValueRef Op1;
        public LValueRef Result;

        public LFneg(LValueRef op1, LValueRef result) {
            Op1 = op1;
            Result = result;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(Result.Identifier);
            sb.Append(" = ").Append(LKeywords.Fneg).Append(" ");

            sb.Append(Op1.ParseType()).Append(" ").Append(Op1.ValueOrIdentifier);
            return sb.ToString();
        }
    }
}
