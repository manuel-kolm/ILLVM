using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'udiv' instruction returns the quotient of its two operands.
    /// </summary>
    public class LUdiv : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        private bool _exact;

        public bool Exact {
            get => _exact;
            set => _exact = value;
        }

        public LUdiv(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for udiv.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LUdiv(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for udiv.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Udiv).Append(" ");
            if (Exact) {
                sb.Append(LKeywords.Exact).Append(" ");
            }
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }
    }
}
