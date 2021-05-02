using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM {
    /// <summary>
    /// This is not an internal LLVM IR functionality.
    /// It's only a helper tool to store and load from stack.
    /// </summary>
    [Obsolete]
    public class LStack {
        private readonly Stack<LType> _stack = new Stack<LType>();

        public void Push(LValueRef valueRef) {
            _stack.Push(valueRef.Type);
        }

        public LValueRef Pop<T>() where T : LType {
            if (_stack.Count == 0) {
                throw new Exception("sdsd");
            }

            return new LValueRef(_stack.Pop(), "sd");
        }
    }
}
