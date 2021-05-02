using ILLVM.Misc;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM {
    public class LConstant {
        public static Action? AssertValidConstantTypeHook;

        /// <summary>
        /// Holds reference information to constant type. (identifier + type)
        /// </summary>
        public readonly LBaseRef TypeRef;
        private string _value;

        /// <summary>
        /// Gets or sets value of constant.
        /// </summary>
        public string Value {
            get => _value;
            set => _value = value;
        }

        public LConstant(LBaseRef typeRef, string identifier, string value) {
            // Validate identifier -> throws exception if invalid.
            LIdentifierValidator.Validate(identifier, TypeOfIdentifier.Constant);
            // Check if the given type ref is allowed for usage as a constant.
            AssertValidConstantType(typeRef);

            TypeRef = typeRef;
            _value = value;
        }

        private void AssertValidConstantType(LBaseRef typeRef) {
            if (AssertValidConstantTypeHook != null) {
                AssertValidConstantTypeHook.Invoke();
                return;
            }

            if (typeRef.IsValue()) {
                LValueRef valueRef = (LValueRef)typeRef;
                switch (valueRef.Type.CheckedCast<LPrimitiveType>().Type) {
                    case LPrimitiveTypes.@bool
                        | LPrimitiveTypes.i8
                        | LPrimitiveTypes.i16
                        | LPrimitiveTypes.i32
                        | LPrimitiveTypes.i64
                        | LPrimitiveTypes.i128
                        | LPrimitiveTypes.u8
                        | LPrimitiveTypes.u16
                        | LPrimitiveTypes.u32
                        | LPrimitiveTypes.u64
                        | LPrimitiveTypes.u128
                        | LPrimitiveTypes.f32
                        | LPrimitiveTypes.f64:
                        break;
                    default:
                        throw new Exception("Used not allowed primitive type for constant. Actual primitive type: " + valueRef.ParseType());
                }
            } else {
                throw new Exception("Used not allowed type ref for constant (or maybe currently not implemented). Actual type: " + typeRef.ParseType());
            }
        }

        public string Parse() {
            throw new NotImplementedException();
        }
    }
}
