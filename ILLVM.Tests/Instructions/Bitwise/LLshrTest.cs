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
    public class LLshrTest {
        private LValueRef _valueResult  = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1     = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2     = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleLshr_ResultFromDifferentType_Expected_Exception() {
            LLshr lshr;
            Assert.Throws<Exception>(() =>
                lshr = new LLshr(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_Op1FromDifferentType_Expected_Exception() {
            LLshr lshr;
            Assert.Throws<Exception>(() =>
                lshr = new LLshr(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_Op2FromDifferentType_Expected_Exception() {
            LLshr lshr;
            Assert.Throws<Exception>(() =>
                lshr = new LLshr(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleLshr_FloatingPointResultType_Expected_Exception() {
            LLshr lshr;
            Assert.Throws<Exception>(() =>
                lshr = new LLshr(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleLshr_ParseCheck() {
            LLshr lshr = new LLshr(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = lshr {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(lshr.ParseInstruction()));
        }

        [Test]
        public void SimpleLshr_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LLshr lshr = new LLshr(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = lshr {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                LHelper.Trim(lshr.ParseInstruction()));
        }

        [Test]
        public void SimpleLshr_Exact_ParseCheck() {
            LLshr lshr = new LLshr(_valueResult, _valueOp1, _valueOp2) {
                Exact = true
            };
            Assert.AreEqual($"{_valueResult.Identifier} = lshr exact {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(lshr.ParseInstruction()));
        }
    }
}
