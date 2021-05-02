using ILLVM.Instructions.Memory;
using ILLVM.Instructions.Other;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests {
    class LFunctionTest {
        [Test]
        public void SimpleLabel_RegisterInstructionTest_NoException() {
            var func = LFunction.Create("foo_function", new LValueRef(LType.Int32Type(), ""));
            func.Register(new LLabelType("entry"));

            Assert.DoesNotThrow(() => {
                var alloca = func.Register(new LAlloca(func, LType.F32Type()));
                var pointerRef = alloca.PointerRef;
                var load = func.Register(new LLoad(func, pointerRef));
            });
        }

        [Test]
        public void AdvancedLabel_RegisterInstructionByLabelTest_NoException() {
            var func = LFunction.Create("foo_function", new LValueRef(LType.Int32Type(), ""));
            var label1 = func.Register(new LLabelType("entry"));
            var label2 = func.Register(new LLabelType("label2"));

            Assert.DoesNotThrow(() => {
                var alloca = func.Register(new LAlloca(func, LType.F32Type()));
                var pointerRef = alloca.PointerRef;
                var load = func.Register(label1, new LLoad(func, pointerRef));
            });
        }

        [Test]
        public void AdvancedLabel_RegisterInstructionByLabelTest_LabelNotFound_Exception() {
            var func = LFunction.Create("foo_function", new LValueRef(LType.Int32Type(), ""));
            var label1 = func.Register(new LLabelType("entry"));
            var label2 = new LLabelType("label2");

            Assert.Throws<Exception>(() => {
                var alloca = func.Register(new LAlloca(func, LType.F32Type()));
                var pointerRef = alloca.PointerRef;
                var load = func.Register(label2, new LLoad(func, pointerRef));
            });
        }
    }
}
