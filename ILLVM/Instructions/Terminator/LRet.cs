using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using ILLVM.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Terminator {
    /// <summary>
    /// The 'ret' instruction is used to return control flow (and optionally a value) from a function back to the caller.
    /// There are two forms of the ‘ret’ instruction: one that returns a value and then causes control flow, and one that just causes control flow to occur.
    /// </summary>
    public class LRet : ILBaseInstr {
        public readonly LBaseRef RetValue;

        public LRet(LBaseRef retValue) {
            RetValue = retValue;
        }
        
        public string ParseInstruction() {
            if (RetValue.IsValue() && RetValue.BaseType.IsPrimitiveType() &&
                RetValue.BaseType.CheckedCast<LPrimitiveType>().Type == LPrimitiveTypes.@void) {
                return $"\t{LKeywords.Ret} {LKeywords.Void}";
            }

            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LKeywords.Ret).Append(" ");
            sb.Append(RetValue.ParseType()).Append(" ").Append(LRefHelper.GetValueOrIdentifierOf(RetValue));
            return sb.ToString();
        }
    }
}
