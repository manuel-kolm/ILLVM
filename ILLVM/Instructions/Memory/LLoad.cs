using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The ‘load’ instruction is used to read from memory.
    /// </summary>
    public class LLoad : ILBaseInstr {
        public readonly LPointerRef PointerRef;
        public readonly LValueRef ValueRef;
        private bool _isVolatile;
        private bool _isAtomic;
        private int? _alignment;

        public bool IsVolatile {
            get => _isVolatile;
            set => _isVolatile = value;
        }

        public bool IsAtomic {
            get => _isAtomic;
            set => _isAtomic = value;
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

        public LLoad(LFunction function, LPointerRef pointerRef) {
            PointerRef = pointerRef;
            ValueRef = new LValueRef(PointerRef.BaseType, function.GetValueRefIdentifier());
        }

        public LValueRef GetValue() {
            return ValueRef;
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(ValueRef.Identifier).Append(" = ").Append(LKeywords.Load).Append(" ");

            if (IsVolatile && !IsAtomic) {
                sb.Append(LKeywords.Volatile).Append(" ");
            } else if (!IsVolatile && IsAtomic) {
                sb.Append(LKeywords.Atomic).Append(" ");
            } else if (IsVolatile && IsAtomic) {
                sb.Append(LKeywords.Atomic).Append(" ").Append(LKeywords.Volatile).Append(" ");
            }

            sb.Append(PointerRef.ParseParentType()).Append(", ");
            sb.Append(PointerRef.ParseType()).Append(" ").Append(PointerRef.Identifier);

            if (Alignment.HasValue) {
                sb.Append(", ").Append(LKeywords.Align).Append(" ").Append(Alignment.Value);
            }

            return sb.ToString();
        }
    }
}
