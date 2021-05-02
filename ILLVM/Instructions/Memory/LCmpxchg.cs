using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The ‘cmpxchg’ instruction is used to atomically modify memory.
    /// It loads a value in memory and compares it to a given value.
    /// If they are equal, it tries to store a new value into the memory.
    /// </summary>
    class LCmpxchg : ILBaseInstr {
        /// <summary>
        /// identified struct type: { ty, i1 }
        /// </summary>
        public readonly LValueRef YieldValueRef;
        public readonly LPointerRef PointerRef;
        public readonly LValueRef CmpValueRef;
        public readonly LValueRef NewValueRef;
        private bool _isWeak;
        private bool _isVolatile;
        private int? _alignment;

        public bool IsWeak {
            get => _isWeak;
            set => _isWeak = value;
        }

        public bool IsVolatile {
            get => _isVolatile;
            set => _isVolatile = value;
        }

        public int? Alignment {
            get => _alignment;
            set {
                if (value > (1 << 29)) {
                    throw new System.Exception("Alignment may not be greater than 1 << 29. Actual alignment: " + value);
                }
                _alignment = value;
            }
        }

        public LCmpxchg(LFunction function, LPointerRef pointerRef, LValueRef cmpValueRef, LValueRef newValueRef) {
            PointerRef = pointerRef;
            CmpValueRef = cmpValueRef;
            NewValueRef = newValueRef;

            // add validation

            //YieldValueRef = new LValueRef(LType.LiteralStructType(LType.Int32Type(), LType.Int8Type()), function.GetValueRefIdentifier());
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LKeywords.Cmpxchg);
            sb.Append(" ");

            if (IsWeak) {
                sb.Append("weak ");
            }
            if (IsVolatile) {
                sb.Append("volatile ");
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
