using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Bitwise {
    /// <summary>
    /// The 'and' instruction returns the bitwise logical and of its two operands.
    /// </summary>
    public class LAnd : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;

        public LAnd(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for and.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LAnd(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for and.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.And).Append(" ");
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }
    }
}
