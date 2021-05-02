using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Types;

namespace ILLVM.References {
    public abstract class LBaseRef {
        /// <summary>
        /// Returns base first class type.
        /// (e.g. i8, i32, u32, ...)
        /// </summary>
        public abstract LType BaseType { get; }

        /// <summary>
        /// Returns if whether this is a array reference or not.
        /// </summary>
        /// <returns><code>true</code> if this is a array reference</returns>
        public virtual bool IsArray() => false;
        /// <summary>
        /// Returns if whether this is a pointer reference or not.
        /// </summary>
        /// <returns><code>true</code> if this is a pointer reference</returns>
        public virtual bool IsPointer() => false;
        /// <summary>
        /// Returns if whether this is a value reference or not.
        /// </summary>
        /// <returns><code>true</code> if this is a value reference</returns>
        public virtual bool IsValue() => false;
        /// <summary>
        /// Returns if whether this is a vector reference or not.
        /// </summary>
        /// <returns><code>true</code> if this is a vector reference</returns>
        public virtual bool IsVector() => false;

        /// <summary>
        /// Parses reference type name. (i8*, u32, {i32, i32}, e.g.)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual string ParseType() {
            throw new NotImplementedException();
        }
    }
}
