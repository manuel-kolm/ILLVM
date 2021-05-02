using ILLVM.Const;
using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The ‘store’ instruction is used to write to memory.
    /// </summary>
    public class LStore : ILBaseInstr {
        public readonly LValueRef Source;
        public readonly LPointerRef Destination;
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

        public LStore(LValueRef source, LPointerRef destination) {
            Source = source;
            Destination = destination;

            // Validate // source and destination same type.
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(LKeywords.Store).Append(" ");

            if (IsVolatile && !IsAtomic) {
                sb.Append(LKeywords.Volatile).Append(" ");
            } else if (!IsVolatile && IsAtomic) {
                sb.Append(LKeywords.Atomic).Append(" ");
            } else if (IsVolatile && IsAtomic) {
                sb.Append(LKeywords.Atomic).Append(" ").Append(LKeywords.Volatile).Append(" ");
            }

            sb.Append(Source.ParseType()).Append(" ").Append(Source.ValueOrIdentifier).Append(", ");
            sb.Append(Destination.ParseType()).Append(" ").Append(Destination.Identifier);

            if (Alignment.HasValue) {
                sb.Append(", ").Append(LKeywords.Align).Append(" ").Append(Alignment.Value);
            }

            return sb.ToString();
        }
    }
}
