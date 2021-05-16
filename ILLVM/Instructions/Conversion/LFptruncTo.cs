using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'fptrunc' instruction truncates value to type ty2.
    /// </summary>
    public class LFptruncTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LFptruncTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsFloatingPoint() || !value.Type.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fptrunc ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LFptruncTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsFloatingPoint() || !value.BaseType.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fptrunc ... to instruction." +
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
            StringBuilder sb = new StringBuilder(LRefHelper.GetValueOrIdentifierOf(Result));
            sb.Append(" = ").Append(LKeywords.Fptrunc);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
