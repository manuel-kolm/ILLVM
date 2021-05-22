using System;
using ILLVM;
using ILLVM.References;
using ILLVM.Types;

namespace SimpleCalculator {
    class Program {
        static void Main(string[] args) {
            string valueIdentifier = "@value";
            string value = "c\"Simple calculator!\\00\"";

            var module = new LModule("LLVMHelloWorld");
            var func = LFunction.Create("@main", new LValueRef(LType.Int32Type(), ""));
        }
    }
}
