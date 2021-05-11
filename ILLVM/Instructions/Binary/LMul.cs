using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'mul' instruction returns the product of its two operands.
    /// </summary>
    public class LMul : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        private bool _noUnsignedWrap;
        private bool _noSignedWrap;

        public bool NoUnsignedWrap {
            get => _noUnsignedWrap;
            set => _noUnsignedWrap = value;
        }

        public bool NoSignedWrap {
            get => _noSignedWrap;
            set => _noSignedWrap = value;
        }

        public LMul(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for mul.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LMul(LVectorRef result, LVectorRef op1, LVectorRef op2) {
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
            sb.Append(" = ").Append(LKeywords.Mul).Append(" ");
            if (NoUnsignedWrap) {
                sb.Append(LKeywords.Nuw).Append(" ");
            }
            if (NoSignedWrap) {
                sb.Append(LKeywords.Nsw).Append(" ");
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