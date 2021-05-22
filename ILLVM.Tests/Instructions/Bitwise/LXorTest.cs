using ILLVM.Instructions.Bitwise;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Bitwise {
    public class LXorTest {
        private LValueRef _valueResult = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1 = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2 = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleXor_ResultFromDifferentType_Expected_Exception() {
            LXor xor;
            Assert.Throws<Exception>(() =>
                xor = new LXor(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleXor_Op1FromDifferentType_Expected_Exception() {
            LXor xor;
            Assert.Throws<Exception>(() =>
                xor = new LXor(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleXor_Op2FromDifferentType_Expected_Exception() {
            LXor xor;
            Assert.Throws<Exception>(() =>
                xor = new LXor(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleXor_FloatingPointResultType_Expected_Exception() {
            LXor xor;
            Assert.Throws<Exception>(() =>
                xor = new LXor(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleXor_ParseCheck() {
            LXor xor = new LXor(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = xor {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(xor.ParseInstruction()));
        }

        [Test]
        public void SimpleXor_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LXor xor = new LXor(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = xor {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                LHelper.Trim(xor.ParseInstruction()));
        }
    }
}
