using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The ‘getelementptr’ instruction is used to get the address of a subelement of an aggregate data structure.
    /// It performs address calculation only and does not access memory. The instruction can also be used to calculate a vector of such addresses.
    /// </summary>
    public class LGetelementptr : ILBaseInstr {
        public readonly LPointerRef PointerRef;
        public readonly LPointerRef ResultRef;
        private bool? _inbounds;
        private List<(LType, int)> _indexes = new List<(LType, int)>();

        public bool? Inbounds {
            get => _inbounds;
            set => _inbounds = value;
        }

        public List<(LType, int)> Indexes {
            get => _indexes;
        }

        public LGetelementptr(LPointerRef resultRef, LPointerRef pointerRef) {
            ResultRef = resultRef;
            PointerRef = pointerRef;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(ResultRef.Identifier);
            sb.Append(" = ").Append(LKeywords.Getelementptr).Append(" ");
            if (Inbounds.HasValue && Inbounds.Value) {
                sb.Append(LKeywords.Inbounds).Append(" ");
            }
            sb.Append(PointerRef.ParseParentType()).Append(", ");

            // Pointer ref
            sb.Append(PointerRef.ParseType()).Append(" ").Append(PointerRef.Identifier);
            
            // Indexes
            foreach(var index in Indexes) {
                sb.Append(", ").Append(index.Item1.Parse()).Append(" ").Append(index.Item2);
            }

            return sb.ToString();
        }
    }
}
