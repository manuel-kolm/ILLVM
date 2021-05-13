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
        private LValueRef _valueResult  = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1     = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2     = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleFadd_ResultFromDifferentType_Expected_Exception() {
            LFadd fadd;
            Assert.Throws<Exception>(() =>
                fadd = new LFadd(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleFadd_Op1FromDifferentType_Expected_Exception() {
            LFadd fadd;
            Assert.Throws<Exception>(() =>
                fadd = new LFadd(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleFadd_Op2FromDifferentType_Expected_Exception() {
            LFadd fadd;
            Assert.Throws<Exception>(() =>
                fadd = new LFadd(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleFadd_FloatingPointResultType_Expected_Exception() {
            LFadd fadd;
            Assert.Throws<Exception>(() =>
                fadd = new LFadd(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }
    }
}
