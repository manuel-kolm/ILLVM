using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types {
    public class LPrimitiveType : LType {
        public readonly LPrimitiveTypes Type;

        public LPrimitiveType(LPrimitiveTypes type) {
            Type = type;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Parse() {
            return Type.Parse();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override bool IsPrimitiveType() => true;
    }

    public enum LPrimitiveTypes {
        i8,
        i16,
        i32,
        i64,
        i128,
        i256,
        u8,
        u16,
        u32,
        u64,
        u128,
        u256,
        f32,
        f64,
        @bool,
        @void,
        vararg
    }

    public static class LPrimitiveTypesExt {
        /// <summary>
        /// Parses <see cref="LPrimitiveTypes"/> into a valid string representation.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string Parse(this LPrimitiveTypes self) {
            return self switch {
                LPrimitiveTypes.i8 => "i8",
                LPrimitiveTypes.i16 => "i16",
                LPrimitiveTypes.i32 => "i32",
                LPrimitiveTypes.i64 => "i64",
                LPrimitiveTypes.i128 => "i128",
                LPrimitiveTypes.i256 => "i256",
                LPrimitiveTypes.u8 => "i8",
                LPrimitiveTypes.u16 => "i16",
                LPrimitiveTypes.u32 => "i32",
                LPrimitiveTypes.u64 => "i64",
                LPrimitiveTypes.u128 => "i128",
                LPrimitiveTypes.u256 => "i256",
                LPrimitiveTypes.f32 => "float",
                LPrimitiveTypes.f64 => "double",
                LPrimitiveTypes.@bool => "i1",
                LPrimitiveTypes.@void => "void",
                LPrimitiveTypes.vararg => "...",
                _ => throw new Exception("Unable to parse invalid primitive type. Type: " + self.ToString()),
            };
        }
    }
}
