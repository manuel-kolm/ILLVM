﻿using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Binary {
    /// <summary>
    /// The 'frem' instruction returns the remainder from the division of its two operands.
    /// </summary>
    public class LFrem : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Op1;
        public readonly LBaseRef Op2;
        private List<LFastMathFlags> _fastMathFlags = new List<LFastMathFlags>();

        public List<LFastMathFlags> FastMathFlags {
            get => _fastMathFlags;
        }

        public LFrem(LValueRef result, LValueRef op1, LValueRef op2) {
            if (result.Type != op1.Type || op1.Type != op2.Type) {
                throw new Exception($"Types of operands or result are not equal. Result: {result.ParseType()}" +
                    $", Op1: {op1.ParseType()}, Op2: {op2.ParseType()}");
            }
            if (!result.Type.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for frem.");
            }

            Result = result;
            Op1 = op1;
            Op2 = op2;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Frem).Append(" ");
            foreach (LFastMathFlags flag in FastMathFlags) {
                sb.Append(flag.Parse()).Append(" ");
            }
            sb.Append(Result.ParseType()).Append(" ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op1)).Append(", ");
            sb.Append(LRefHelper.GetValueOrIdentifierOf(Op2));
            return sb.ToString();
        }
    }
}
