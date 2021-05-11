using ILLVM.Instructions.Binary;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Binary {
    public class LFaddTest {
        private LValueRef _valueResult  = new LValueRef(LType.F32Type(), "%result");
        private LValueRef _valueOp1     = new LValueRef(LType.F32Type(), "%op1");
        private LValueRef _valueOp2     = new LValueRef(LType.F32Type(), "%op2");

        [Test]
        public void SimpleFadd_ResultFromDifferentType_Expected_Exception() {
            LAdd add;
            Assert.Throws<Exception>(() =>
                add = new LAdd(new LValueRef(LType.F64Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleFadd_Op1FromDifferentType_Expected_Exception() {
            LAdd add;
            Assert.Throws<Exception>(() =>
                add = new LAdd(_valueResult, new LValueRef(LType.F64Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleFadd_Op2FromDifferentType_Expected_Exception() {
            LAdd add;
            Assert.Throws<Exception>(() =>
                add = new LAdd(_valueResult, _valueOp1, new LValueRef(LType.F64Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleFadd_IntegerResultType_Expected_Exception() {
            LAdd add;
            Assert.Throws<Exception>(() =>
                add = new LAdd(new LValueRef(LType.F64Type(), "%result"), _valueOp1, _valueOp2)
            );
        }
    }
}
