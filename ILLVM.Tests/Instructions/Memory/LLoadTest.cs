using ILLVM.Const;
using ILLVM.Instructions.Memory;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Memory {
    class LLoadTest {
        private LFunction _function = new LFunction("foo", new LValueRef(LType.Int32Type(), ""));
        private LAlloca _alloca;

        [SetUp]
        public void SetUp() {
            _alloca = new LAlloca(_function, LType.Int32Type());
        }

        [Test]
        public void SimpleLoadAlignmentExceeded_Expected_Exception() {
            LLoad load;

            Assert.Throws<Exception>(() =>
            load = new LLoad(_function, _alloca.PointerRef) {
                Alignment = 1 << 30
            });
        }

        [Test]
        public void SimpleLoadParse_Expected_True() {
            LLoad load = new LLoad(_function, _alloca.PointerRef);
            Assert.AreEqual(
                $"{load.ValueRef.Identifier} = {LKeywords.Load} {LType.Int32Type().Parse()}, {load.PointerRef.ParseType()} {load.PointerRef.Identifier}",
                load.ParseInstruction());
        }

        [Test]
        public void LoadParseAlignment_Expected_True() {
            LLoad load = new LLoad(_function, _alloca.PointerRef) {
                Alignment = 2048
            };
            Assert.AreEqual(
                $"{load.ValueRef.Identifier} = {LKeywords.Load} {LType.Int32Type().Parse()}, {load.PointerRef.ParseType()} {load.PointerRef.Identifier}, {LKeywords.Align} {2048}",
                load.ParseInstruction());
        }

        [Test]
        public void LoadParseIsVolatile_Expected_True() {
            LLoad load = new LLoad(_function, _alloca.PointerRef) {
                IsVolatile = true
            };
            Assert.AreEqual(
                $"{load.ValueRef.Identifier} = {LKeywords.Load} {LKeywords.Volatile} {LType.Int32Type().Parse()}, {load.PointerRef.ParseType()} {load.PointerRef.Identifier}",
                load.ParseInstruction());
        }

        [Test]
        public void LoadParseIsAtomicVolatile_Expected_True() {
            LLoad load = new LLoad(_function, _alloca.PointerRef) {
                IsAtomic = true,
                IsVolatile = true
            };
            Assert.AreEqual(
                $"{load.ValueRef.Identifier} = {LKeywords.Load} {LKeywords.Atomic} {LKeywords.Volatile} {LType.Int32Type().Parse()}, {load.PointerRef.ParseType()} {load.PointerRef.Identifier}",
                load.ParseInstruction());
        }

        [Test]
        public void LoadParseIsAtomicVolatileAlignment_Expected_True() {
            LLoad load = new LLoad(_function, _alloca.PointerRef) {
                IsAtomic = true,
                IsVolatile = true,
                Alignment = 5012
            };
            Assert.AreEqual(
                $"{load.ValueRef.Identifier} = {LKeywords.Load} {LKeywords.Atomic} {LKeywords.Volatile} {LType.Int32Type().Parse()}, {load.PointerRef.ParseType()} {load.PointerRef.Identifier}, {LKeywords.Align} {5012}",
                load.ParseInstruction());
        }
    }
}
