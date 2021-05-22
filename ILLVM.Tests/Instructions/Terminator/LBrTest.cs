using System;
using ILLVM.Const;
using ILLVM.Instructions.Memory;
using ILLVM.Instructions.Terminator;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;

namespace ILLVM.Tests.Instructions.Terminator
{
    public class LBrTest
    {
        private readonly LFunction _function = new LFunction("foo", new LValueRef(LType.Int32Type(), ""));
        private readonly LLabelType _ifTrueLabel = new LLabelType("%ifTrue");
        private readonly LLabelType _ifFalseLabel = new LLabelType("%ifFalse");

        [Test]
        public void ConditionalBr_TypeCheck_i32_Exception() {
            LConditionalBr conditionalBr;

            Assert.Throws<Exception>(() =>
                conditionalBr = new LConditionalBr(
                    new LValueRef(LType.Int32Type(), _function.GetValueRefIdentifier()),
                    _ifTrueLabel, _ifFalseLabel)
            );
        }
        
        [Test]
        public void ConditionalBr_TypeCheck_i8_Success() {
            LConditionalBr conditionalBr;

            Assert.DoesNotThrow(() =>
                conditionalBr = new LConditionalBr(
                    new LValueRef(LType.BoolType(), _function.GetValueRefIdentifier()),
                    _ifTrueLabel, _ifFalseLabel)
            );
        }
        
        [Test]
        public void ConditionalBr_ParseCheck() {
            LValueRef condition = new LValueRef(LType.BoolType(), _function.GetValueRefIdentifier());
            LConditionalBr conditionalBr = new LConditionalBr(
                condition, _ifTrueLabel, _ifFalseLabel);

            Assert.AreEqual(
                $"{LKeywords.Br} i1 {condition.ValueOrIdentifier}, {LKeywords.Label} {_ifTrueLabel.Identifier}, {LKeywords.Label} {_ifFalseLabel.Identifier}",
                LHelper.Trim(conditionalBr.ParseInstruction()));
        }
        
        [Test]
        public void UnconditionalBr_ParseCheck() {
            LUnconditionalBr unconditionalBr = new LUnconditionalBr(_ifTrueLabel);

            Assert.AreEqual(
                $"{LKeywords.Br} {LKeywords.Label} {_ifTrueLabel.Identifier}",
                LHelper.Trim(unconditionalBr.ParseInstruction()));
        }
    }
}