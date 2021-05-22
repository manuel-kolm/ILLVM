using ILLVM.Instructions.Binary;
using ILLVM.Instructions.Bitwise;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Bitwise {
    public class LAshrTest {
        private LValueRef _valueResult  = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1     = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2     = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleAshr_ResultFromDifferentType_Expected_Exception() {
            LAshr ashr;
            Assert.Throws<Exception>(() =>
                ashr = new LAshr(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleAshr_Op1FromDifferentType_Expected_Exception() {
            LAshr ashr;
            Assert.Throws<Exception>(() =>
                ashr = new LAshr(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleAshr_Op2FromDifferentType_Expected_Exception() {
            LAshr ashr;
            Assert.Throws<Exception>(() =>
                ashr = new LAshr(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleAshr_FloatingPointResultType_Expected_Exception() {
            LAshr ashr;
            Assert.Throws<Exception>(() =>
                ashr = new LAshr(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleAshr_ParseCheck() {
            LAshr ashr = new LAshr(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = ashr {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(ashr.ParseInstruction()));
        }

        [Test]
        public void SimpleAshr_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LAshr ashr = new LAshr(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = ashr {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                LHelper.Trim(ashr.ParseInstruction()));
        }

        [Test]
        public void SimpleAshr_Exact_ParseCheck() {
            LAshr ashr = new LAshr(_valueResult, _valueOp1, _valueOp2) {
                Exact = true
            };
            Assert.AreEqual($"{_valueResult.Identifier} = ashr exact {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(ashr.ParseInstruction()));
        }
    }
}
