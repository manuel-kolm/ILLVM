using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Bitwise {
    /// <summary>
    /// The 'shl' instruction returns the first operand shifted to the left a specified number of bits.
    /// </summary>
    public class LShl : ILBaseInstr {
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

        public LShl(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for shl.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LShl(LVectorRef result, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for shl.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Shl).Append(" ");
            if (NoUnsignedWrap) {
                sb.Append(LKeywords.Nuw).Append(" ");
            }
            if (NoSignedWrap) {
                sb.Append(LKeywords.Nsw).Append(" ");
            }
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }
    }
}
