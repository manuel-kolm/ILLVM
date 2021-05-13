using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types {
    public enum LStructType {
        Identified,
        Literal,
        Packed
    }

    public class LStruct : LType {
        /// <summary>
        /// This identifier is only used for identified structs and doesn't represent a value identifier at all.
        /// (Only the struct name)
        /// </summary>
        public readonly string? Identifier;
        public readonly LStructType StructType;
        public readonly LType[] Members;

        public LStruct(string? identifier, LStructType structType, params LType[] members) {
            // Add checks
            Identifier = identifier;
            StructType = structType;
            Members = members;
        }


        /// <summary>
        /// TODO: Rename function.
        /// </summary>
        /// <returns></returns>
        public string ParseIdentifiedStructDef() {
            if (StructType != LStructType.Identified) {
                throw new Exception("Can't parse def for . . . ");
            }

            StringBuilder sb = new StringBuilder(Identifier);
            sb.Append(" = type { ");

            for (int i = 0; i < Members.Length; ++i) {
                if (i != 0) {
                    sb.Append(", ");
                }
                sb.Append(Members[i].Parse());
            }

            sb.Append(" }");

            return sb.ToString();
        }

        public override string Parse() {
            if (StructType == LStructType.Identified) {
                return Identifier!;
            }
            StringBuilder sb = new StringBuilder();

            if (StructType == LStructType.Packed) {
                sb.Append("<");
            }

            sb.Append("{ ");

            for (int i = 0; i < Members.Length; ++i) {
                if (i != 0) {
                    sb.Append(", ");
                }
                sb.Append(Members[i].Parse());
            }

            sb.Append(" }");

            if (StructType == LStructType.Packed) {
                sb.Append(">");
            }

            return sb.ToString();
        }
    }
}
