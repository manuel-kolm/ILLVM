using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Bitwise {
    /// <summary>
    /// The 'ashr' instruction (arithmetic shift right) returns the first operand shifted to the right a specified number of bits with sign extension.
    /// </summary>
    public class LAshr : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        private bool _exact;

        public bool Exact {
            get => _exact;
            set => _exact = value;
        }

        public LAshr(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for ashr.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LAshr(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for ashr.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(GetValueOrIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Ashr).Append(" ");
            if (Exact) {
                sb.Append(LKeywords.Exact).Append(" ");
            }
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
