using System.Collections;
using System.Collections.Generic;
using System.Text;
using ILLVM.Const;
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
        public readonly List<(int, LLabelType)> JumpTableDestinations;

        public LSwitch(LValueRef valueRef, LLabelType defaultDestination) {
            ValueRef = valueRef;
            DefaultDestination = defaultDestination;
            JumpTableDestinations = new List<(int, LLabelType)>();
        }

        public string ParseInstruction() {
            string typeSpecifier = ValueRef.Type.Parse();

            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LKeywords.Switch).Append(" ");
            sb.Append(typeSpecifier).Append(" ").Append(ValueRef.ValueOrIdentifier);
            sb.Append(", ").Append(LKeywords.Label).Append(" ").Append(DefaultDestination.Identifier);
            sb.Append(" [ ");

            int index = sb.Length;
            for (int i = 0; i < JumpTableDestinations.Count; ++i) {
                if (i != 0) {
                    sb.AppendLine().Append("\t".PadRight(index));
                }

                sb.Append(typeSpecifier).Append(" ").Append(JumpTableDestinations[i].Item1).Append(", ");
                sb.Append(LKeywords.Label).Append(" ").Append(JumpTableDestinations[i].Item2.Identifier);
            }

            if (JumpTableDestinations.Count > 0) {
                sb.Append(" ");
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}