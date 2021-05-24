using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The 'cmpxchg' instruction is used to atomically modify memory.
    /// It loads a value in memory and compares it to a given value.
    /// If they are equal, it tries to store a new value into the memory.
    /// </summary>
    class LCmpxchg : ILBaseInstr {
        /// <summary>
        /// identified struct type: { ty, i1 }
        /// </summary>
        public readonly LValueRef YieldRef;
        public readonly LPointerRef PointerRef;
        public readonly LValueRef CmpValueRef;
        public readonly LValueRef NewValueRef;
        public readonly LOrdering SucessOrdering;
        public readonly LOrdering FailureOrdering;
        private int? _alignment;

        public bool IsWeak { get; set; }
        public bool IsVolatile { get; set; }
        public int? Alignment {
            get => _alignment;
            set {
                if (value > (1 << 29)) {
                    throw new System.Exception("Alignment may not be greater than 1 << 29. Actual alignment: " + value);
                }
                _alignment = value;
            }
        }

        public LCmpxchg(LValueRef yieldRef, LPointerRef pointerRef, LValueRef cmpValueRef, LValueRef newValueRef, LOrdering successOrdering, LOrdering failureOrdering) {
            YieldRef = yieldRef;
            PointerRef = pointerRef;
            CmpValueRef = cmpValueRef;
            NewValueRef = newValueRef;
            SucessOrdering = successOrdering;
            FailureOrdering = failureOrdering;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(YieldRef.Identifier).Append(" = ").Append(LKeywords.Cmpxchg).Append(" ");

            if (IsWeak) {
                sb.Append(LKeywords.Weak).Append(" ");
            }
            if (IsVolatile) {
                sb.Append(LKeywords.Volatile).Append(" ");
            }

            sb.Append(PointerRef.ParseType()).Append(" ").Append(PointerRef.Identifier).Append(", ");
            sb.Append(CmpValueRef.ParseType()).Append(" ").Append(CmpValueRef.Identifier).Append(", ");
            sb.Append(NewValueRef.ParseType()).Append(" ").Append(NewValueRef.Identifier);

            if (Alignment.HasValue) {
                sb.Append(", ").Append(LKeywords.Align).Append(" ").Append(Alignment.Value);
            }

            return sb.ToString();
        }
    }
}
