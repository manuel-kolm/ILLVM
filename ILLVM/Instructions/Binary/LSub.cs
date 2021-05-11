using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'sub' instruction returns the difference of its two operands.
    /// Note that the 'sub' instruction is used to represent the 'neg' instruction present in most other intermediate representations.
    /// </summary>
    public class LSub : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;

        public LSub(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for sub.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LSub(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.BaseType != op1.BaseType || op1.BaseType != op2.BaseType) {
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
            sb.Append(" = ").Append(LKeywords.Sub).Append(" ");
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
