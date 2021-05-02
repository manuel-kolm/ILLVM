using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.References {
    class LValueRefTest {
        private LFunction _function = new LFunction("foo", new LValueRef(LType.Int32Type(), ""));

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void Test1() {
            LValueRef valueRef = new LValueRef(new LStruct("fooStruct", LStructType.Identified, LType.Int32Type(), LType.Int64Type()), _function.GetValueRefIdentifier());
            String sd = valueRef.ParseType();

            Console.WriteLine(sd);
        }
    }
}
