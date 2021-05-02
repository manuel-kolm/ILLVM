using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;

namespace ILLVM.Tests.References {
    public class LArrayRefTest {

        [Test]
        public void PointerArrayRef_Expected_NoException() {
            LPointerRef pointerRef = new LPointerRef(new LValueRef(LType.Int32Type(), ""), "pointerRef");
            LArrayRef arrayRef;

            Assert.DoesNotThrow(() =>
                arrayRef = new LArrayRef("arrayRef2", pointerRef, 5)
            );
        }

        [Test]
        public void DoubleArrayRef_Expected_NoException() {
            LArrayRef arrayRef = new LArrayRef("arrayRef", new LValueRef(LType.Int32Type(), ""), 5);
            LArrayRef arrayRef2;

            Assert.DoesNotThrow(() =>
                arrayRef2 = new LArrayRef("arrayRef2", arrayRef, 5)
            );
        }

        [Test]
        public void DoubleValueArrayRef_ParseCheck_Expected_Equals() {
            LArrayRef arrayRef = new LArrayRef("arrayRef", new LValueRef(LType.Int32Type(), ""), 5);
            LArrayRef arrayRef2 = new LArrayRef("arrayRef2", arrayRef, 5);
            Assert.AreEqual("[5 x i32]", arrayRef.ParseType());
            Assert.AreEqual("[5 x [5 x i32]]", arrayRef2.ParseType());
        }

        [Test]
        public void DoublePointerArrayRef_ParseCheck_Expected_Equals() {
            LArrayRef arrayRef = new LArrayRef("arrayRef", new LPointerRef(new LValueRef(LType.Int32Type(), ""), "pointerRef"), 5);
            LArrayRef arrayRef2 = new LArrayRef("arrayRef2", arrayRef, 5);
            Assert.AreEqual("[5 x i32*]", arrayRef.ParseType());
            Assert.AreEqual("[5 x [5 x i32*]]", arrayRef2.ParseType());
        }
    }
}