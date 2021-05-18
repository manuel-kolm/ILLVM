using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Misc;
using ILLVM.Types;

namespace ILLVM.References {
    /// <summary>
    /// TODO
    /// </summary>
    public class LPointerRef : LBaseRef {
        public readonly string Identifier;
        public readonly LBaseRef ParentRef;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => ParentRef.BaseType;

        public LPointerRef(LBaseRef parentRef, string identifier) {
            ParentRef = parentRef;
            Identifier = identifier;
        }

        public LPointerRef(LBaseRef parentRef) {
            string identifier = LRefHelper.GetIdentifierOf(parentRef);
            if (String.IsNullOrEmpty(identifier)) {
                throw new Exception("Parent references which don't use any identifier are not valid.");
            }

            Identifier = identifier;
            ParentRef = parentRef;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override bool IsPointer() => true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ParseType() {
            return ParentRef.ParseType() + "*";
        }

        public string ParseParentType() {
            return ParentRef.ParseType();
        }
    }
}
