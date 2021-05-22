using ILLVM.Enums;
using ILLVM.Instructions.Unary;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Unary {
    public class LFnegTest {
        private readonly LValueRef _op1 = new LValueRef(LType.F32Type(), "%1");
        private readonly LValueRef _result = new LValueRef(LType.F32Type(), "%result");

        [Test]
        public void SimpleFneg_Op1Int32_Exception() {
            LFneg fneg;

            Assert.Throws<Exception>(() =>
                fneg = new LFneg(new LValueRef(LType.Int32Type(), "%result"), _result)
            );
        }

        [Test]
        public void SimpleFneg_ResultInt32_Exception() {
            LFneg fneg;

            Assert.Throws<Exception>(() =>
                fneg = new LFneg(_op1, new LValueRef(LType.Int32Type(), "%result"))
            );
        }

        [Test]
        public void SimpleFneg_ResultHasNoIdentifier_Exception() {
            LFneg fneg;

            Assert.Throws<Exception>(() =>
                fneg = new LFneg(_op1, new LValueRef(LType.F32Type(), "1.000000e+00"))
            );
        }

        [Test]
        public void Fneg_ParseCheck() {
            LFneg fneg = new LFneg(_op1, _result);
            Assert.AreEqual($"{_result.Identifier} = fneg {_result.ParseType()} {_op1.ValueOrIdentifier}",
                LHelper.Trim(fneg.ParseInstruction()));
        }

        [Test]
        public void Fneg_ParseCheck_FastMathFlags() {
            LFneg fneg = new LFneg(_op1, _result);
            fneg.Flags.Add(LFastMathFlags.fast);
            Assert.AreEqual($"{_result.Identifier} = fneg {LFastMathFlags.fast.Parse()} {_result.ParseType()} {_op1.ValueOrIdentifier}",
                LHelper.Trim(fneg.ParseInstruction()));
        }
    }
}
