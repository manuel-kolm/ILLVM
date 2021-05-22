using ILLVM.Const;
using ILLVM.Misc;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Conversion {
    /// <summary>
    /// The 'ptrtoint' instruction converts the pointer or a vector of pointers value to the integer (or vector of integers) type ty2.
    /// </summary>
    public class LPtrtointTo : ILBaseInstr {
        public readonly LBaseRef Result;
        public readonly LBaseRef Value;

        public LPtrtointTo(LValueRef result, LPointerRef value) {
            if (!result.Type.IsIntegral() || !value.BaseType.IsIntegral()) {
                throw new Exception("Only floating point types are allowed for ptrtoint ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            Result = result;
            Value = value;
        }

        public LPtrtointTo(LVectorRef result, LVectorRef value) {
            if (!result.BaseType.IsIntegral() || !value.BaseType.IsIntegral()) {
                throw new Exception("Only floating point types are allowed for ptrtoint ... to instruction." +
                    $"Result: {result.ParseType()}, Value: {value.ParseType()}");
            }
            if (result.ParseType() + "*" != value.ParseType()) {
                throw new Exception("not equal");
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
            sb.Append(LRefHelper.GetIdentifierOf(Result)).Append(" = ").Append(LKeywords.Ptrtoint);
            sb.Append(Value.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(Value));
            sb.Append(" ").Append(LKeywords.To).Append(" ").Append(Result.ParseType());
            return sb.ToString();
        }
    }
}
