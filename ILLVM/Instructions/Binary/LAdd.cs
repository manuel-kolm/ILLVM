using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'add' instruction returns the sum of its two operands.
    /// </summary>
    public class LAdd : ILBaseInstr {
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

        public LAdd(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for add.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public LAdd(LVectorRef result, LVectorRef op1, LVectorRef op2) {
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
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Add).Append(" ");
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
