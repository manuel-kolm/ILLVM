﻿using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'sext' sign extends value to the type ty2.
    /// </summary>
    public class LSextTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LSextTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsIntegral() || !value.Type.IsIntegral()) {
                throw new Exception("Only integer types are allowed for sext ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LSextTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsIntegral() || !value.BaseType.IsIntegral()) {
                throw new Exception("Only integer types are allowed for sext ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            if (result.Size != value.Size) {
                throw new Exception("Vector size of result and value set are not equal." +
                    $"Result: {result.Size}, Value: {value.Size}");
            }
            Result = result;
            Value = value;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Sext);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
