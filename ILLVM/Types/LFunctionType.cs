using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types {
    /// <summary>
    /// The function type can be thought of as a function signature.
    /// It consists of a return type and a list of formal parameter types.
    /// The return type of a function type is a void type or first class type — except for label and metadata types.
    /// </summary>
    public class LFunctionType : LType {
        public readonly LBaseRef ReturnType;
        public readonly LBaseRef[] Parameters;
        private bool? _hasVararg;

        public bool? HasVararg {
            get => _hasVararg;
            set => _hasVararg = value;
        }

        public LFunctionType(LBaseRef returnType, params LBaseRef[] parameters) {
            if (returnType.IsArray()) {
                throw new Exception("A function type can have attributes of type array.");
            }
            foreach (var parameter in parameters) {
                if (parameter.IsArray()) {
                    throw new Exception("A function type can have attributes of type array.");
                }
            }

            ReturnType = returnType;
            Parameters = parameters;
        }

        public override string Parse() {
            StringBuilder sb = new StringBuilder(ReturnType.ParseType());

            sb.Append(" (");
            for (int i = 0; i < Parameters.Length; ++i) {
                if (i > 0) {
                    sb.Append(", ");
                }
                sb.Append(Parameters[i].ParseType());
            }
            if (HasVararg.HasValue && HasVararg.Value) {
                sb.Append(", ...");
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}
