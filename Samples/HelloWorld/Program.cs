using ILLVM;
using ILLVM.Instructions.Memory;
using ILLVM.Instructions.Other;
using ILLVM.Instructions.Terminator;
using ILLVM.References;
using ILLVM.Types;
using System;

namespace HelloWorld {
    class Program {
        static void Main(string[] args) {
            string valueIdentifier = "@value";
            string value = "c\"Hello World!\\00\"";

            var module = new LModule("LLVMHelloWorld");
            var func = LFunction.Create("@main", new LValueRef(LType.Int32Type(), ""));

            var arrayRef = new LArrayRef(valueIdentifier, new LValueRef(LType.Int8Type(), ""), 0);
            // Create char array constant.
            var global = new LGlobal(arrayRef, value) {
                IsConstant = true
            };

            var fnType = new LFunctionType(new LValueRef(LType.Int32Type(), "%printf"), new LPointerRef(new LValueRef(LType.Int8Type(), ""), "%result")) {
                HasVararg = true
            };
            var external = new LExternal(fnType, "@printf");

            var result = new LPointerRef(new LValueRef(LType.Int8Type(), ""), "%result");
            var gep = new LGetelementptr(result, global.GetPointerRef());
            gep.Indexes.Add((LType.Int32Type(), 0));
            gep.Indexes.Add((LType.Int32Type(), 13));

            var call = new LCall(fnType, external.FnIdentifier);

            var ret = new LRet(new LValueRef(LType.Int32Type(), "0"));

            // Create and register entry label
            func.Register(new LLabelType("entry"));
            // Register function and char array constant to module.
            module.Register(global);
            module.Register(func);
            module.Register(external);
            // Register instructions.
            func.Register(gep);
            func.Register(call);
            func.Register(ret);

            Console.WriteLine(module.Parse());
        }
    }
}
