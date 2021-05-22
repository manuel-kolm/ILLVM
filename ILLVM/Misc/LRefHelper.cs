using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Misc {
    public static class LRefHelper {
        /// <summary>
        /// Returns value or identifier of reference.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>value or identifier</returns>
        public static string GetValueOrIdentifierOf(LBaseRef reference) {
            if (reference.IsValue()) {
                LValueRef value = (LValueRef)reference;
                return value.ValueOrIdentifier;
            } else if (reference.IsPointer()) {
                LPointerRef pointer = (LPointerRef)reference;
                return pointer.Identifier;
            } else if (reference.IsArray()) {
                LArrayRef array = (LArrayRef)reference;
                return array.Identifier;
            } else if (reference.IsVector()) {
                LVectorRef vector = (LVectorRef)reference;
                return vector.ValueOrIdentifier;
            }
            throw new Exception("unknown reference.");
        }

        /// <summary>
        /// Returns identifier of reference.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>identifier</returns>
        public static string GetIdentifierOf(LBaseRef reference) {
            if (reference.IsValue()) {
                LValueRef value = (LValueRef)reference;
                return value.Identifier!;
            } else if (reference.IsPointer()) {
                LPointerRef pointer = (LPointerRef)reference;
                return pointer.Identifier;
            } else if (reference.IsArray()) {
                LArrayRef array = (LArrayRef)reference;
                return array.Identifier;
            } else if (reference.IsVector()) {
                LVectorRef vector = (LVectorRef)reference;
                return vector.Identifier!;
            }
            throw new Exception("unknown reference.");
        }
    }
}
