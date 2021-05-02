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
        private readonly LBaseRef _parentRef;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => _parentRef.BaseType;

        public LPointerRef(LBaseRef parentRef, string identifier) {
            _parentRef = parentRef;
            Identifier = identifier;
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
            return _parentRef.ParseType() + "*";
        }

        public string ParseParentType() {
            return _parentRef.ParseType();
        }
    }
}
