using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The ‘sitofp’ instruction regards value as a signed integer and converts that value to the ty2 type.
    /// </summary>
    public class LSitofpTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LSitofpTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsFloatingPoint() || !value.Type.IsIntegral()) {
                throw new Exception("Result must be a floating point and value an integer type for uitofp ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LSitofpTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsFloatingPoint() || !value.BaseType.IsIntegral()) {
                throw new Exception("Result must be a floating point and value an integer type for uitofp ... to instruction." +
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
            sb.Append(" = ").Append(LKeywords.Sitofp);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
