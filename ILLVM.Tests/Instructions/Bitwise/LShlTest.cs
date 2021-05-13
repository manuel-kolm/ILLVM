using ILLVM.Instructions.Bitwise;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Bitwise {
    class LShlTest {
        private LValueRef _valueResult = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1 = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2 = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleLshr_ResultFromDifferentType_Expected_Exception() {
            LShl shl;
            Assert.Throws<Exception>(() =>
                shl = new LShl(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_Op1FromDifferentType_Expected_Exception() {
            LShl shl;
            Assert.Throws<Exception>(() =>
                shl = new LShl(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_Op2FromDifferentType_Expected_Exception() {
            LShl shl;
            Assert.Throws<Exception>(() =>
                shl = new LShl(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleLshr_FloatingPointResultType_Expected_Exception() {
            LShl shl;
            Assert.Throws<Exception>(() =>
                shl = new LShl(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_ParseCheck() {
            LShl shl = new LShl(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = shl {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                shl.ParseInstruction());
        }

        [Test]
        public void SimpleLshr_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LShl shl = new LShl(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = shl {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                shl.ParseInstruction());
        }

        [Test]
        public void SimpleLshr_Nuw_ParseCheck() {
            LShl shl = new LShl(_valueResult, _valueOp1, _valueOp2) {
                NoUnsignedWrap = true,
            };
            Assert.AreEqual($"{_valueResult.Identifier} = shl nuw {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                shl.ParseInstruction());
        }

        [Test]
        public void SimpleLshr_Nsw_ParseCheck() {
            LShl shl = new LShl(_valueResult, _valueOp1, _valueOp2) {
                NoSignedWrap = true,
            };
            Assert.AreEqual($"{_valueResult.Identifier} = shl nsw {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                shl.ParseInstruction());
        }

        [Test]
        public void SimpleLshr_NuwNsw_ParseCheck() {
            LShl shl = new LShl(_valueResult, _valueOp1, _valueOp2) {
                NoUnsignedWrap = true,
                NoSignedWrap = true,
            };
            Assert.AreEqual($"{_valueResult.Identifier} = shl nuw nsw {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                shl.ParseInstruction());
        }
    }
}
