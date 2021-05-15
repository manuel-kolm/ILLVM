using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Other {
    /// <summary>
    /// The ‘fcmp’ instruction returns a boolean value or vector of boolean values based on comparison of its operands.
    /// If the operands are floating-point scalars, then the result type is a boolean(i1).
    /// If the operands are floating-point vectors, then the result type is a vector of boolean with the same number of elements as the operands being compared.
    /// </summary>
    public class LFcmp : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        public readonly LFCondition Condition;
        private List<LFastMathFlags> _fastMathFlags = new List<LFastMathFlags>();

        public List<LFastMathFlags> FastMathFlags {
            get => _fastMathFlags;
        }

        public LFcmp(LValueRef result, LFCondition condition, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (!result.Type.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fcmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public LFcmp(LPointerRef result, LFCondition condition, LPointerRef op1, LPointerRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (!result.BaseType.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fcmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public LFcmp(LVectorRef result, LFCondition condition, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (!result.BaseType.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fcmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(GetValueOrIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Fcmp).Append(" ");
            foreach (LFastMathFlags flag in FastMathFlags) {
                sb.Append(flag.Parse()).Append(" ");
            }
            sb.Append(Condition.Parse()).Append(" ");
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }

        private string GetValueOrIdentifierOf(LBaseRef reference) {
            if (reference is LValueRef value) {
                return value.ValueOrIdentifier!;
            } else if (reference is LPointerRef pointer) {
                return pointer.Identifier;
            }
            return ((LVectorRef)reference).ValueOrIdentifier;
        }
    }
}
