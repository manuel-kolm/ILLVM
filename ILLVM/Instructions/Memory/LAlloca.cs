using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Text;

namespace ILLVM.Instructions.Memory {
    /// <summary>
    /// The 'alloca' instruction allocates memory on the stack frame of the currently executing function, to be automatically released when this function returns to its caller.
    /// The object is always allocated in the address space for allocas indicated in the datalayout.
    /// </summary>
    public class LAlloca : ILBaseInstr {
        public LPointerRef PointerRef;
        private int? _numOfElements;
        private int? _alignment;
        private int? _addrspace;

        public int? NumOfElements {
            get => _numOfElements;
            set => _numOfElements = value;
        }

        public int? Alignment {
            get => _alignment;
            set {
                if (value > (1 << 29)) {
                    throw new System.Exception("Alignment may not be greater than 1 << 29. Actual alignment: " + value);
                }
                _alignment = value;
             }
        }

        public int? Addrspace {
            get => _addrspace;
            set => _addrspace = value;
        }

        /// <summary>
        /// Creates 'alloca' instruction from first class type.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="type"></param>
        public LAlloca(LFunction function, LType type) {
            PointerRef = new LPointerRef(new LValueRef(type, null), function.GetPointerRefIdentifier());
        }

        /// <summary>
        /// Creates 'alloca' instruction from pointer reference.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="pointer"></param>
        public LAlloca(LFunction function, LPointerRef pointer) {
            PointerRef = new LPointerRef(pointer, function.GetPointerRefIdentifier());
        }

        /// <summary>
        /// Creates 'alloca' instruction from struct type.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="struct"></param>
        public LAlloca(LFunction function, LStruct @struct) {
            PointerRef = new LPointerRef(new LValueRef(@struct, null), function.GetPointerRefIdentifier());
        }

        public string ParseInstruction() {
            StringBuilder sb = new StringBuilder(PointerRef.Identifier).Append(" = ").Append(LKeywords.Alloca).Append(" ");
            sb.Append(PointerRef.ParseParentType());
            if (NumOfElements.HasValue) {
                sb.Append(", ").Append(PointerRef.ParseParentType()).Append(" ").Append(NumOfElements.Value);
            }
            if (Alignment.HasValue) {
                sb.Append(", ").Append(LKeywords.Align).Append(" ").Append(Alignment.Value);
            }
            if (Addrspace.HasValue) {
                sb.Append(", ").Append(LKeywords.Addrspace).Append("(").Append(Addrspace.Value).Append(")");
            }
            return sb.ToString();
        }
    }
}