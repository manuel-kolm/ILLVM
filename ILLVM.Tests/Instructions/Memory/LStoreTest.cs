using ILLVM.Const;
using ILLVM.Instructions.Memory;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Memory {
    class LStoreTest {
        private LPointerRef _dst;
        private LValueRef _src;

        [SetUp]
        public void SetUp() {
            _dst = new LPointerRef(new LValueRef(LType.Int32Type(), ""), "%ptr");
            _src = new LValueRef(LType.Int32Type(), "%val");
        }

        [Test]
        public void SimpleLoadAlignmentExceeded_Expected_Exception() {
            LStore store;

            Assert.Throws<Exception>(() =>
            store = new LStore(_src, _dst) {
                Alignment = 1 << 30
            });
        }

        [Test]
        public void SimpleLoadTypesUnequal_Expected_Exception() {
            LStore store;

            Assert.Throws<Exception>(() =>
                store = new LStore(_src, new LPointerRef(_dst, "%ptr1"))
            );
        }

        [Test]
        public void StoreAlignment_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                Alignment = 5012
            };
            Assert.AreEqual(
                $"{LKeywords.Store} {_src.ParseType()} {_src.ValueOrIdentifier}, {_dst.ParseType()} {_dst.Identifier}, {LKeywords.Align} 5012",
                LHelper.Trim(store.ParseInstruction()));
        }

        [Test]
        public void StoreIsVolatile_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                IsVolatile = true
            };
            Assert.AreEqual(
                $"{LKeywords.Store} {LKeywords.Volatile} {_src.ParseType()} {_src.ValueOrIdentifier}, {_dst.ParseType()} {_dst.Identifier}",
                LHelper.Trim(store.ParseInstruction()));
        }

        [Test]
        public void StoreIsAtomic_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                IsAtomic = true
            };
            Assert.AreEqual(
                $"{LKeywords.Store} {LKeywords.Atomic} {_src.ParseType()} {_src.ValueOrIdentifier}, {_dst.ParseType()} {_dst.Identifier}",
                LHelper.Trim(store.ParseInstruction()));
        }

        [Test]
        public void StoreIsAtomicVolatile_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                IsAtomic = true,
                IsVolatile = true
            };
            Assert.AreEqual(
                $"{LKeywords.Store} {LKeywords.Atomic} {LKeywords.Volatile} {_src.ParseType()} {_src.ValueOrIdentifier}, {_dst.ParseType()} {_dst.Identifier}",
                LHelper.Trim(store.ParseInstruction()));
        }

        [Test]
        public void StoreIsAtomicVolatileAlignment_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                IsAtomic = true,
                IsVolatile = true,
                Alignment = 5012
            };
            Assert.AreEqual(
                $"{LKeywords.Store} {LKeywords.Atomic} {LKeywords.Volatile} {_src.ParseType()} {_src.ValueOrIdentifier}, {_dst.ParseType()} {_dst.Identifier}, {LKeywords.Align} 5012",
                LHelper.Trim(store.ParseInstruction()));
        }

        [Test]
        public void StoreIsAtomicVolatileAlignment_Hardcoded_Expected_Ok() {
            LStore store = new LStore(_src, _dst) {
                IsAtomic = true,
                IsVolatile = true,
                Alignment = 5012
            };
            Assert.AreEqual(
                $"store atomic volatile i32 {_src.ValueOrIdentifier}, i32* {_dst.Identifier}, align 5012",
                LHelper.Trim(store.ParseInstruction()));
        }
    }
}
