using ILLVM.Instructions.Memory;
using ILLVM.Instructions.Other;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;

namespace ILLVM.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //var func = LFunction.Create("foo_function", new LValueRef(LType.Int32Type(), ""));
            //var label = new LLabelType("entry");

            //var alloca = new LAlloca(func, LType.F32Type());
            //var pointerRef = alloca.PointerRef;
            //var load = new LLoad(func, pointerRef);

            //string fnIdentifier = "@foo_printf";

            //var returnValue = new LValueRef(LType.Int32Type(), func.GetValueRefIdentifier());
            //var args = new LBaseRef[] { load.ValueRef };
            //var fnType = new LFunctionType(returnValue.Type, load.ValueRef.Type);

            //var external = new LExternal(returnValue, fnIdentifier, args);
            //var call = new LCall(returnValue, fnType, fnIdentifier, args);

            //string externalDef = external.Parse();
            //string callDef = call.ParseInstruction();
            //System.Console.WriteLine(callDef);

            //var global = new LGlobal(new LValueRef(LType.UInt32Type(), "@my_global_int"), "1245632");
            //string globalDef = global.Parse();

            //System.Console.WriteLine(globalDef);

            // func.Register(label);
            //
            // var alloca = func.Register(new LAlloca(func, LType.F32Type()));
            // var pointerRef = alloca.PointerRef;
            // var load = new LLoad(func, pointerRef);
            // var valueRef = load.ValueRef;
            //
            // //func.Register(alloca);
            // func.Register(load);
            //
            // string sb = (func.Parse());
            // System.Console.WriteLine(sb);

        }
    }
}