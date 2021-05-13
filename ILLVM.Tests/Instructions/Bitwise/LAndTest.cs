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
    public class LAndTest {
        private LValueRef _valueResult  = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1     = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2     = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleAnd_ResultFromDifferentType_Expected_Exception() {
            LAnd and;
            Assert.Throws<Exception>(() =>
                and = new LAnd(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleAnd_Op1FromDifferentType_Expected_Exception() {
            LAnd and;
            Assert.Throws<Exception>(() =>
                and = new LAnd(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleAnd_Op2FromDifferentType_Expected_Exception() {
            LAnd and;
            Assert.Throws<Exception>(() =>
                and = new LAnd(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleAnd_FloatingPointResultType_Expected_Exception() {
            LAnd and;
            Assert.Throws<Exception>(() =>
                and = new LAnd(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleAnd_ParseCheck() {
            LAnd and = new LAnd(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = and {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                and.ParseInstruction());
        }

        [Test]
        public void SimpleAnd_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LAnd and = new LAnd(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = and {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                and.ParseInstruction());
        }
    }
}
