using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'uitofp' instruction regards value as an unsigned integer and converts that value to the ty2 type.
    /// </summary>
    public class LUitofpTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LUitofpTo(LValueRef result, LValueRef value) {
            if (!result.Type.IsFloatingPoint() || !value.Type.IsIntegral()) {
                throw new Exception("Result must be a floating point and value an integer type for uitofp ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LUitofpTo(LVectorRef result, LVectorRef value) {
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
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Uitofp);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
