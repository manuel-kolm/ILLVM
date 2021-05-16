using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types {
    /// <summary>
    /// A literal struct represents a tuple struct type which is not identified.
    /// </summary>
    public class LLiteralStruct : LStruct {
        public readonly LBaseRef[] Members;

        public LLiteralStruct(params LBaseRef[] members) {
            Members = members;
        }

        public override bool IsLiteralStruct() => true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>type definition</returns>
        public override string Parse() {
            StringBuilder sb = new StringBuilder("{ ");

            for (int i = 0; i < Members.Length; ++i) {
                if (i != 0) {
                    sb.Append(", ");
                }
                sb.Append(Members[i].ParseType());
            }

            sb.Append(" }");
            return sb.ToString();
        }
    }
}
