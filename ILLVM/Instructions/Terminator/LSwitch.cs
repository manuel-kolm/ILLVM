using System.Collections;
using System.Collections.Generic;
using System.Text;
using ILLVM.References;
using ILLVM.Types;

namespace ILLVM.Instructions.Terminator {
    /// <summary>
    /// The 'switch' instruction is used to transfer control flow to one of several different places.
    /// It is a generalization of the ‘br’ instruction, allowing a branch to occur to one of many possible destinations.
    /// </summary>
    public class LSwitch : ILBaseInstr {
        public readonly LValueRef ValueRef;
        public readonly LLabelType DefaultDestination;
        public readonly Dictionary<int, LLabelType> JumpTableDestinations;
        
        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("switch ");
            sb.Append(ValueRef.Type.Parse()).Append(ValueRef.ValueOrIdentifier);
            sb.Append(", label ").Append(ValueRef.Identifier);
            
            // jump table

            return sb.ToString();
        }
    }
}