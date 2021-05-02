using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Misc {
    public enum TypeOfIdentifier {
        LocalVariable,
        GlobalVariable,
        Constant,
        Function,
        Label
    }

    public static class LIdentifierValidator {
        public static string Validate(string identifier, TypeOfIdentifier typeOfIdentifier) {
            return typeOfIdentifier switch {
                TypeOfIdentifier.Constant => ValidateConstantIdentifier(identifier),
                TypeOfIdentifier.GlobalVariable => ValidateGlobalVariableIdentifier(identifier),
                TypeOfIdentifier.LocalVariable => ValidateLocalVariableIdentifier(identifier),
                TypeOfIdentifier.Function => ValidateFunctionIdentifier(identifier),
                TypeOfIdentifier.Label => ValidateLabelIdentifier(identifier),
                _ => throw new Exception($"Unknown type of identifier. Actual type: {typeOfIdentifier}"),
            };
        }

        private static string ValidateConstantIdentifier(string identifier) {
            if (!identifier.StartsWith("@")) {
                throw new Exception($"Constant identifier should start with a @-prefix. Actual identifier: {identifier}");
            }
            return identifier;
        }

        private static string ValidateGlobalVariableIdentifier(string identifier) {
            if (!identifier.StartsWith("@")) {
                throw new Exception($"Global variable identifier should start with a @-prefix. Actual identifier: {identifier}");
            }
            return identifier;
        }

        private static string ValidateLocalVariableIdentifier(string identifier) {
            if (!identifier.StartsWith("%")) {
                throw new Exception($"Local variable identifier should start with a @-prefix. Actual identifier: {identifier}");
            }
            return identifier;
        }

        private static string ValidateFunctionIdentifier(string identifier) {
            if (!identifier.StartsWith("@")) {
                throw new Exception($"Function identifier should start with a @-prefix. Actual identifier: {identifier}");
            }
            return identifier;
        }

        private static string ValidateLabelIdentifier(string identifier) {
            if (!identifier.StartsWith("@")) {
                throw new Exception($"Label identifier should start with a @-prefix. Actual identifier: {identifier}");
            }
            return identifier;
        }
    }
}
