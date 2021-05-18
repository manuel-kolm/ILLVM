using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Other {
    /// <summary>
    /// The 'icmp' instruction returns a boolean value or a vector of boolean values based on comparison of its two integer, integer vector, pointer, or pointer vector operands.
    /// </summary>
    public class LIcmp : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        public readonly LICondition Condition;

        public LIcmp(LValueRef result, LICondition condition, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.Type.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for icmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public LIcmp(LPointerRef result, LICondition condition, LPointerRef op1, LPointerRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for icmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public LIcmp(LVectorRef result, LICondition condition, LVectorRef op1, LVectorRef op2) {
            if (result.ParseType() != op1.ParseType() || op1.ParseType() != op2.ParseType()) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (result.BaseType.IsFloatingPoint()) {
                throw new Exception("Floating point types are not allowed for icmp.");
            }

            Result = result;
            Condition = condition;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Icmp).Append(" ");
            sb.Append(Condition.Parse()).Append(" ");
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }
    }
}
