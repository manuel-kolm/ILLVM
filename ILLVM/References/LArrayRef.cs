using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Misc;
using ILLVM.Types;

namespace ILLVM.References {
    /// <summary>
    /// Represents an array reference. Can hold a value or array data type.
    /// </summary>
    public class LArrayRef : LBaseRef {
        public readonly string Identifier;
        public readonly LBaseRef ParentRef;
        public readonly int Size;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => ParentRef.BaseType;

        public LArrayRef(string identifier, LBaseRef parentRef, int size) {
            Identifier = identifier;
            ParentRef = parentRef;
            Size = size;
        }

        public LArrayRef(LBaseRef parentRef, int size) {
            string identifier = LRefHelper.GetIdentifierOf(parentRef);
            if (String.IsNullOrEmpty(identifier)) {
                throw new Exception("Parent references which don't use any identifier are not valid.");
            }

            Identifier = identifier;
            ParentRef = parentRef;
            Size = size;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override bool IsArray() => true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ParseType() {
            return new StringBuilder("[").Append(Size).Append(" x ").Append(ParentRef.ParseType()).Append("]").ToString();
        }

        public string ParseParentType() {
            return ParentRef.ParseType();
        }

        public static LArrayRef CreateFrom(LType type, string identifier, int size) {
            return new LArrayRef(identifier, new LValueRef(type, identifier), size);
        }
    }
}
