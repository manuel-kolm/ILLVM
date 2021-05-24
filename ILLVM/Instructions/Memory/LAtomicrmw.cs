using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    class LAtomicrmw : ILBaseInstr {
        public readonly LValueRef YieldRef;
        public readonly LPointerRef PointerRef;
        public readonly LValueRef ValueRef;
        public readonly LAtomicrmwOperand Operand;
        public readonly LOrdering Ordering;
        private int? _alignment;

        public bool IsVolatile { get; set; }
        public int? Alignment {
            get => _alignment;
            set {
                if (value > (1 << 29)) {
                    throw new Exception("Alignment may not be greater than 1 << 29. Actual alignment: " + value);
                }
                _alignment = value;
            }
        }

        public LAtomicrmw(LValueRef yieldRef, LPointerRef pointerRef, LValueRef valueRef, LAtomicrmwOperand operand, LOrdering ordering) {
            YieldRef = yieldRef;
            PointerRef = pointerRef;
            ValueRef = valueRef;
            Operand = operand;
            Ordering = ordering;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LKeywords.Atomicrmw).Append(" ");

            if (IsVolatile) {
                sb.Append(LKeywords.Volatile).Append(" ");
            }
            sb.Append(Operand.Parse()).Append(" ");
            sb.Append(PointerRef.ParseType()).Append(" ").Append(PointerRef.Identifier).Append(", ");
            sb.Append(ValueRef.ParseType()).Append(" ").Append(ValueRef.Identifier).Append(" ").Append(Ordering.Parse());

            if (Alignment.HasValue) {
                sb.Append(", ").Append(LKeywords.Align).Append(" ").Append(Alignment.Value);
            }

            return sb.ToString();
        }
    }
}
