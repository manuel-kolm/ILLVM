using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types
{
    /// <summary>
    /// Base implementation of a type specifier.
    /// </summary>
    public abstract class LType
    {
        /// <summary>
        /// Parses and returns typespecifier or identifier depending on data type.
        /// </summary>
        /// <returns>typespecifier</returns>
        public virtual string Parse() => throw new NotImplementedException();

        public virtual bool IsPrimitiveType() => false;

        public virtual bool IsStructType() => IsPackedStruct() || IsIdentifiedStruct() || IsLiteralStruct() || IsOpaqueStruct();

        public virtual bool IsPackedStruct() => false;

        public virtual bool IsIdentifiedStruct() => false;

        public virtual bool IsLiteralStruct() => false;

        public virtual bool IsOpaqueStruct() => false;

        public virtual bool IsFloatingPoint() => false;

        public virtual bool IsIntegral() => false;

        public virtual bool IsSigned() => false;

        public virtual bool IsUnsigned() => false;

        public static LType Int8Type() => new LPrimitiveType(LPrimitiveTypes.i8);

        public static LType Int16Type() => new LPrimitiveType(LPrimitiveTypes.i16);

        public static LType Int32Type() => new LPrimitiveType(LPrimitiveTypes.i32);

        public static LType Int64Type() => new LPrimitiveType(LPrimitiveTypes.i64);

        public static LType Int128Type() => new LPrimitiveType(LPrimitiveTypes.i128);

        public static LType Int256Type() => new LPrimitiveType(LPrimitiveTypes.i256);

        public static LType UInt8Type() => new LPrimitiveType(LPrimitiveTypes.u8);

        public static LType UInt16Type() => new LPrimitiveType(LPrimitiveTypes.u16);

        public static LType UInt32Type() => new LPrimitiveType(LPrimitiveTypes.u32);

        public static LType UInt64Type() => new LPrimitiveType(LPrimitiveTypes.u64);

        public static LType UInt128Type() => new LPrimitiveType(LPrimitiveTypes.u128);

        public static LType UInt256Type() => new LPrimitiveType(LPrimitiveTypes.u256);

        public static LType F32Type() => new LPrimitiveType(LPrimitiveTypes.f32);

        public static LType F64Type() => new LPrimitiveType(LPrimitiveTypes.f64);

        public static LType BoolType() => new LPrimitiveType(LPrimitiveTypes.@bool);

        public static LType VoidType() => new LPrimitiveType(LPrimitiveTypes.@void);

        public static LType VarargType() => new LPrimitiveType(LPrimitiveTypes.vararg);

        /// <summary>
        /// Casts object to child implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>casted object or null if cast failed</returns>
        public T? Cast<T>()
            where T : LType
        {
            return this as T;
        }

        /// <summary>
        /// Casts object to child implementation. Throws Exception if object is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>casted object</returns>
        public T CheckedCast<T>()
            where T : LType
        {
            return Cast<T>() ?? throw new NullReferenceException();
        }

        public static bool operator ==(LType a, LType b) {
            return a.Equals(b);
        }

        public static bool operator !=(LType a, LType b) {
            return !(a == b);
        }
    }
}
