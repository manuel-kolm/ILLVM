using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Unary {
    /// <summary>
    /// The 'fneg' instruction returns the negation of its operand.
    /// </summary>
    public class LFneg : ILBaseInstr {
        public LBaseRef Op1;
        public LBaseRef Result;
        private List<LFastMathFlags> _flags = new List<LFastMathFlags>();

        public List<LFastMathFlags> Flags {
            get => _flags;
        }

        public LFneg(LValueRef op1, LValueRef result) {
            if (result.Identifier == null) {
                throw new Exception("Result value reference must be identified.");
            } else if (!result.BaseType.IsFloatingPoint() || !op1.BaseType.IsFloatingPoint()) {
                throw new Exception("Instruction 'fneg' is only valid on floating point types. Actual type: result: " + result.ParseType() + ", op1: " + op1.ParseType());
            }

            Op1 = op1;
            Result = result;
        }

        public LFneg(LVectorRef op1, LVectorRef result) {
            if (!result.BaseType.IsFloatingPoint() || !op1.BaseType.IsFloatingPoint()) {
                throw new Exception("Instruction 'fneg' is only valid on floating point types. Actual type: result: " + result.ParseType() + ", op1: " + op1.ParseType());
            }

            Op1 = op1;
            Result = result;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Fneg).Append(" ");

            foreach (var flag in Flags) {
                sb.Append(flag.Parse()).Append(" ");
            }

            sb.Append(Op1.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Op1));
            return sb.ToString();
        }
    }
}
