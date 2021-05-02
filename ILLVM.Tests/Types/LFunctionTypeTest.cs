using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Types {
    class LFunctionTypeTest {
        [Test]
        public void SimpleFunctionType_ArrayAsReturnVal_Expected_Exception() {
            var returnVal = new LArrayRef("", new LValueRef(LType.F32Type(), ""), 5);
            LFunctionType fnType;

            Assert.Throws<Exception>(() =>
                fnType = new LFunctionType(returnVal)
            );
        }

        [Test]
        public void SimpleFunctionType_ArrayAsParameter_Expected_Exception() {
            var returnVal = new LValueRef(LType.F32Type(), "");
            var parameter = new LArrayRef("", new LValueRef(LType.F32Type(), ""), 5);
            LFunctionType fnType;

            Assert.Throws<Exception>(() =>
                fnType = new LFunctionType(returnVal, parameter)
            );
        }

        [Test]
        public void SimpleFunctionType_ParseCheck() {
            var returnVal = new LValueRef(LType.F32Type(), "");
            var parameter = new LPointerRef(new LValueRef(LType.F32Type(), ""), "");
            LFunctionType fnType = new LFunctionType(returnVal, parameter);

            Assert.AreEqual("float (float*)", fnType.Parse());
        }

        [Test]
        public void VarargFunctionType_ParseCheck() {
            var returnVal = new LValueRef(LType.F32Type(), "");
            var parameter = new LPointerRef(new LValueRef(LType.F32Type(), ""), "");
            LFunctionType fnType = new LFunctionType(returnVal, parameter) {
                HasVararg = true
            };

            Assert.AreEqual("float (float*, ...)", fnType.Parse());
        }
    }
}
