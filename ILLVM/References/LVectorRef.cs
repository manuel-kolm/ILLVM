using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Types;

namespace ILLVM.References {
    /// <summary>
    /// Holds reference to vector datatype.
    /// </summary>
    public class LVectorRef : LBaseRef {
        /// <summary>
        /// Can hold information about value or identifier.
        /// </summary>
        public readonly string ValueOrIdentifier;
        public readonly LType Type;
        public readonly int Size;

        /// <summary>
        /// Returns identifier if current reference is identified, otherwise null.
        /// </summary>
        public string? Identifier {
            get {
                if (!ValueOrIdentifier.StartsWith("%") && !ValueOrIdentifier.StartsWith("@")) {
                    return null;
                }
                return ValueOrIdentifier;
            }
        }

        /// <summary>
        /// Returns value if current reference is not identified, otherwise null.
        /// </summary>
        public string? Value {
            get {
                if (ValueOrIdentifier.StartsWith("%") && ValueOrIdentifier.StartsWith("@")) {
                    return null;
                }
                return ValueOrIdentifier;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => Type;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool IsVector() => true;

        public LVectorRef(LType type, int size, string valueOrIdentifier) {
            Type = type;
            ValueOrIdentifier = valueOrIdentifier;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ParseType() {
            return new StringBuilder("<").Append(Size).Append(" ").Append(Type.Parse()).Append(">").ToString();
        }
    }
}
