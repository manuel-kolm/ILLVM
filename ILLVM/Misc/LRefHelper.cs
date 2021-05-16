using ILLVM.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Misc {
    public static class LRefHelper {
        public static string GetValueOrIdentifierOf(LBaseRef reference) {
            if (reference is LValueRef value) {
                return value.ValueOrIdentifier!;
            } else if (reference is LPointerRef pointer) {
                return pointer.Identifier;
            } else if (reference is LArrayRef array) {
                return array.Identifier;
            } else if (reference is LVectorRef vector) {
                return vector.ValueOrIdentifier;
            }
            throw new Exception("unknown reference.");
        }
    }
}
