using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types {
    public class LIdentifiedStruct : LStruct {
        public readonly string Identifier;
        public readonly LBaseRef[] Members;

        public LIdentifiedStruct(string identifier, params LBaseRef[] members) {
            Identifier = identifier;
            Members = members;
        }

        public override bool IsIdentifiedStruct() => true;

        /// <summary>
        /// Parses struct definition, which needs to be added to the module.
        /// </summary>
        /// <returns></returns>
        public string GetStructDefinition() {
            StringBuilder sb = new StringBuilder(Identifier);
            sb.Append(" = type { ");

            for (int i = 0; i < Members.Length; ++i) {
                if (i != 0) {
                    sb.Append(", ");
                }
                sb.Append(Members[i].ParseType());
            }

            sb.Append(" }");
            return sb.ToString();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>identifier</returns>
        public override string Parse() {
            return Identifier;
        }
    }
}
