using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'srem' instruction returns the remainder from the signed division of its two operands.
    /// This instruction can also take vector versions of the values in which case the elements must be integers.
    /// </summary>
    public class LSrem : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;

        public LSrem(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for srem.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LSrem(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for urem.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(GetValueOrIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Srem).Append(" ");
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }

        private string GetValueOrIdentifierOf(LBaseRef reference) {
            if (reference is LValueRef value) {
                return value.ValueOrIdentifier!;
            }
            return ((LVectorRef)reference).ValueOrIdentifier;
        }
    }
}
