using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.References {
    /// <summary>
    /// Holds reference to value datatype.
    /// </summary>
    public class LValueRef : LBaseRef {
        /// <summary>
        /// Can hold information about value or identifier.
        /// Can also be null if this value ref is only a placeholder.
        /// See <see cref="ILLVM.Instructions.Memory.LLoad"/> for more information.
        /// </summary>
        public readonly string ValueOrIdentifier;
        public readonly LType Type;

        /// <summary>
        /// Returns identifier if current reference is identified or used as a placeholder, otherwise null.
        /// </summary>
        public string? Identifier {
            get {
                if (ValueOrIdentifier!.StartsWith("%") || ValueOrIdentifier!.StartsWith("@")!) {
                    return ValueOrIdentifier;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns value if current reference is not identified or used as a placeholder, otherwise null.
        /// </summary>
        public string? Value {
            get {
                if (ValueOrIdentifier!.StartsWith("%") || ValueOrIdentifier!.StartsWith("@")) {
                    return null;
                }
                return ValueOrIdentifier;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => Type;

        public LValueRef(LType type, string valueOrIdentifier) {
            Type = type;
            ValueOrIdentifier = valueOrIdentifier;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override bool IsValue() => true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ParseType() {
            return Type.Parse();
        }

        public static bool operator ==(LValueRef a, LValueRef b) {
            return a.Type == b.Type;
        }

        public static bool operator !=(LValueRef a, LValueRef b) {
            return !(a == b);
        }
    }
}
