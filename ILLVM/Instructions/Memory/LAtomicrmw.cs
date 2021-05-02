using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Memory {
    class LAtomicrmw : ILBaseInstr {
        public string Operand { get; set; }

        public string ParseInstruction() {
            throw new NotImplementedException();
        }
    }
}
