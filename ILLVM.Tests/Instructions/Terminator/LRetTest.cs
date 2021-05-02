using System;
using ILLVM.Const;
using ILLVM.Instructions.Terminator;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;

namespace ILLVM.Tests.Instructions.Terminator
{
    public class LRetTest
    {
        public class LBrTest
        {
            private readonly LFunction _function = new LFunction("foo", new LValueRef(LType.Int32Type(), ""));

            [Test]
            public void Ret_ParseCheck_Void_Ok() {
                LRet ret = new LRet(new LValueRef(LType.VoidType(), _function.GetValueRefIdentifier()));
                
                Assert.AreEqual($"{LKeywords.Ret} {LKeywords.Void}", ret.ParseInstruction());
            }
            
            [Test]
            public void Ret_ParseCheck_i32_Identifier_Ok() {
                LValueRef valueRef = new LValueRef(LType.Int32Type(), _function.GetValueRefIdentifier());
                LRet ret = new LRet(valueRef);
                
                Assert.AreEqual($"{LKeywords.Ret} i32 {valueRef.ValueOrIdentifier}", ret.ParseInstruction());
            }
            
            [Test]
            public void Ret_ParseCheck_i32_Value_Ok() {
                LValueRef valueRef = new LValueRef(LType.Int32Type(), "12");
                LRet ret = new LRet(valueRef);
                
                Assert.AreEqual($"{LKeywords.Ret} i32 12", ret.ParseInstruction());
            }
        }
    }
}