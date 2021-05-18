using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'trunc' instruction truncates its operand to the type ty2.
    /// </summary>
    public class LTruncTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LTruncTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsIntegral() || !value.Type.IsIntegral()) {
                throw new Exception("Only integer types are allowed for trunc ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LTruncTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsIntegral() || !value.BaseType.IsIntegral()) {
                throw new Exception("Only integer types are allowed for trunc ... to instruction." +
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
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Trunc);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
