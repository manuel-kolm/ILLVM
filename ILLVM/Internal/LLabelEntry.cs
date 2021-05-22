using System.Collections.Generic;
using System.Text;
using ILLVM.Instructions;
using ILLVM.Types;

namespace ILLVM.Internal {
    /// <summary>
    /// Internal representation for label entries.
    /// Stores label type and its containing instructions.
    /// </summary>
    internal class LLabelEntry {
        internal readonly LLabelType Label;
        internal readonly List<ILBaseInstr> Instructions = new List<ILBaseInstr>();

        internal LLabelEntry(LLabelType label) {
            Label = label;
        }

        public void Append(ILBaseInstr instruction) {
            Instructions.Add(instruction);
        }

        public string Parse() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Label.Parse());

            foreach (ILBaseInstr instruction in Instructions)
            {
                sb.Append(instruction.ParseInstruction()).AppendLine();
            }

            return sb.ToString();
        }
    }
}