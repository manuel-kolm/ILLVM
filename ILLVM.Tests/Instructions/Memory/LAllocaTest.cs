using ILLVM.Const;
using ILLVM.Instructions.Memory;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Memory {
    public class LAllocaTest {
        private readonly LFunction _function = new LFunction("foo", new LValueRef(LType.Int32Type(), ""));

        [Test]
        public void SimpleAllocaAlignmentExceeded_Expected_Exception() {
            LAlloca alloca;

            Assert.Throws<Exception>(() => 
            alloca = new LAlloca(_function, LType.Int32Type()) {
                Alignment = 1 << 30
            });
        }

        [Test]
        public void SimpleAllocaParse_Expected_True() {
            LAlloca alloca = new LAlloca(_function, LType.Int32Type());
            Assert.AreEqual(alloca.ParseInstruction(), $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}");
        }

        [Test]
        public void AllocaParseNumOfElements_Expected_True() {
            LAlloca alloca = new LAlloca(_function, LType.Int32Type()) {
                NumOfElements = 5
            };
            Assert.AreEqual(alloca.ParseInstruction(),
                $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}, {LType.Int32Type().Parse()} 5");
        }

        [Test]
        public void AllocaParseAlignment_Expected_True() {
            LAlloca alloca = new LAlloca(_function, LType.Int32Type()) {
                Alignment = 1024
            };
            Assert.AreEqual(alloca.ParseInstruction(),
                $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}, {LKeywords.Align} 1024");
        }

        [Test]
        public void AllocaParseAddrspace_Expected_True() {
            LAlloca alloca = new LAlloca(_function, LType.Int32Type()) {
                Addrspace = 4
            };
            Assert.AreEqual(alloca.ParseInstruction(),
                $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}, {LKeywords.Addrspace}(4)");
        }

        [Test]
        public void AllocaParseNumOfElementsAlignmentAddrspace_Expected_True() {
            LAlloca alloca = new LAlloca(_function, LType.Int32Type()) {
                NumOfElements = 5,
                Alignment = 1024,
                Addrspace = 4
            };
            Assert.AreEqual(alloca.ParseInstruction(),
                $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}, {LType.Int32Type().Parse()} 5, {LKeywords.Align} 1024, {LKeywords.Addrspace}(4)");
        }

        [Test]
        public void AllocaTriplePointerType_Expected_Equal() {
            LPointerRef singlePointer = new LPointerRef(new LValueRef(LType.Int32Type(), ""), _function.GetPointerRefIdentifier());
            LPointerRef doublePointer = new LPointerRef(singlePointer, _function.GetPointerRefIdentifier());
            LAlloca alloca = new LAlloca(_function, doublePointer);
            Assert.AreEqual(alloca.ParseInstruction(), $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {LType.Int32Type().Parse()}**");
            Assert.AreEqual($"{LType.Int32Type().Parse()}***", alloca.PointerRef.ParseType());
        }

        [Test]
        public void AllocaIdentifiedStruct_Expected_Ok() {
            string structIdentifier = "abcTestStruct";
            LAlloca alloca = new LAlloca(_function, LType.IdentifiedStructType(structIdentifier, LType.Int128Type(), LType.Int16Type()));
            Assert.AreEqual(alloca.ParseInstruction(), $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {structIdentifier}");
            Assert.AreEqual($"{structIdentifier}*", alloca.PointerRef.ParseType());
        }

        [Test]
        public void AllocaLiteralStruct_Expected_Ok() {
            LAlloca alloca = new LAlloca(_function, LType.LiteralStructType(LType.Int128Type(), LType.Int16Type()));
            Assert.AreEqual(alloca.ParseInstruction(), $"{alloca.PointerRef.Identifier} = {LKeywords.Alloca} {{ i128, i16 }}");
            Assert.AreEqual("{ i128, i16 }*", alloca.PointerRef.ParseType());
        }
    }
}
