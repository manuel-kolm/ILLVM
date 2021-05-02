using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Terminator {
    /// <summary>
    /// The 'ret' instruction is used to return control flow (and optionally a value) from a function back to the caller.
    /// There are two forms of the ‘ret’ instruction: one that returns a value and then causes control flow, and one that just causes control flow to occur.
    /// </summary>
    public class LRet : ILBaseInstr {
        public readonly LValueRef RetValue;

        public LRet(LValueRef retValue) {
            RetValue = retValue;
        }
        
        public string ParseInstruction() {
            if (RetValue.Type.IsPrimitiveType() &&
                RetValue.Type.CheckedCast<LPrimitiveType>().Type == LPrimitiveTypes.@void) {
                return $"ret {LKeywords.Void}";
            }

            StringBuilder sb = new StringBuilder("ret ");
            sb.Append(RetValue.ParseType()).Append(" ").Append(RetValue.ValueOrIdentifier);
            return sb.ToString();
        }
    }
}
