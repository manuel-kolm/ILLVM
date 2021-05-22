using ILLVM.Instructions.Bitwise;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Bitwise {
    public class LOrTest {
        private LValueRef _valueResult = new LValueRef(LType.Int32Type(), "%result");
        private LValueRef _valueOp1 = new LValueRef(LType.Int32Type(), "%op1");
        private LValueRef _valueOp2 = new LValueRef(LType.Int32Type(), "%op2");

        [Test]
        public void SimpleOr_ResultFromDifferentType_Expected_Exception() {
            LOr or;
            Assert.Throws<Exception>(() =>
                or = new LOr(new LValueRef(LType.Int128Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleOr_Op1FromDifferentType_Expected_Exception() {
            LOr or;
            Assert.Throws<Exception>(() =>
                or = new LOr(_valueResult, new LValueRef(LType.Int128Type(), "%op1"), _valueOp2)
            );
        }

        [Test]
        public void SimpleOr_Op2FromDifferentType_Expected_Exception() {
            LOr or;
            Assert.Throws<Exception>(() =>
                or = new LOr(_valueResult, _valueOp1, new LValueRef(LType.Int128Type(), "%op2"))
            );
        }

        [Test]
        public void SimpleOr_FloatingPointResultType_Expected_Exception() {
            LOr or;
            Assert.Throws<Exception>(() =>
                or = new LOr(new LValueRef(LType.F32Type(), "%result"), _valueOp1, _valueOp2)
            );
        }

        [Test]
        public void SimpleOr_ParseCheck() {
            LOr or = new LOr(_valueResult, _valueOp1, _valueOp2);
            Assert.AreEqual($"{_valueResult.Identifier} = or {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {_valueOp2.ValueOrIdentifier}",
                LHelper.Trim(or.ParseInstruction()));
        }

        [Test]
        public void SimpleOr_WithConstant_ParseCheck() {
            LValueRef op2 = new LValueRef(LType.Int32Type(), "12");
            LOr or = new LOr(_valueResult, _valueOp1, op2);
            Assert.AreEqual($"{_valueResult.Identifier} = or {_valueResult.ParseType()} {_valueOp1.ValueOrIdentifier}, {op2.ValueOrIdentifier}",
                LHelper.Trim(or.ParseInstruction()));
        }
    }
}
