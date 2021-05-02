using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Types;

namespace ILLVM.References
{
    public class LVectorRef : LBaseRef
    {
        public readonly LBaseRef TypeRef;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override LType BaseType => TypeRef.BaseType;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool IsVector() => true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ParseType() {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
