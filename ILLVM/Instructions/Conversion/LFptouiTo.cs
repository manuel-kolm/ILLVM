using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'fptoui' converts a floating-point value to its unsigned integer equivalent of type ty2.
    /// </summary>
    public class LFptouiTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LFptouiTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsFloatingPoint() || !value.Type.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fptoui ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LFptouiTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsFloatingPoint() || !value.BaseType.IsFloatingPoint()) {
                throw new Exception("Only floating point types are allowed for fptoui ... to instruction." +
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
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Fptoui);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
