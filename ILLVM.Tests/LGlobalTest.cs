using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests {
    class LGlobalTest {
        [Test]
        public void GlobalVariable_IsConstantAndExternal_Expected_Exception() {
            string globalVariableIdentifier = "@my_global_int";
            string value = "12345";
            var constant = new LGlobal(new LValueRef(LType.UInt32Type(), globalVariableIdentifier), value) {
                IsConstant = true
            };
            Assert.Throws<Exception>(() => {
                constant.IsExternal = true;
            });
        }

        [Test]
        public void GlobalVariable_IsExternalAndConstant_Expected_Exception() {
            string globalVariableIdentifier = "@my_global_int";
            string value = "12345";
            var global = new LGlobal(new LValueRef(LType.UInt32Type(), globalVariableIdentifier), value) {
                IsExternal = true
            };
            Assert.Throws<Exception>(() => {
                global.IsConstant = true;
            });
        }

        [Test]
        public void BasicGlobalVariable_ParseCheck_Expected_Equal() {
            string globalVariableIdentifier = "@my_global_int";
            string value = "12345";
            var global = new LGlobal(new LValueRef(LType.UInt32Type(), globalVariableIdentifier), value);
            Assert.AreEqual($"{globalVariableIdentifier} = {LKeywords.Global} i32 {value}", global.Parse());
        }

        [Test]
        public void BasicGlobalVariable_CharArray_ParseCheck_Expected_Equal() {
            string globalVariableIdentifier = "@my_global_int";
            string value = "c\"Hello World!\00\"";
            var global = new LGlobal(new LArrayRef(globalVariableIdentifier, new LValueRef(LType.Int8Type(), ""), 13), value) {
                IsConstant = true
            };
            Assert.AreEqual($"{globalVariableIdentifier} = {LKeywords.Constant} [13 x i8] {value}", global.Parse());
        }

        [Test]
        public void BasicGlobalVariable_LocalCharArray_ParseCheck_Expected_Equal() {
            string globalVariableIdentifier = "@my_global_char_array";
            string value = "c\"Hello World!\00\"";
            var global = new LGlobal(new LArrayRef(globalVariableIdentifier, new LValueRef(LType.Int8Type(), ""), 13), value) {
                IsConstant = true,
                RuntimePreemptionSpecifier = Enums.LRuntimePreemptionSpecifier.dso_local
            };
            Assert.AreEqual($"{globalVariableIdentifier} = {LKeywords.DsoLocal} {LKeywords.Constant} [13 x i8] {value}", global.Parse());
        }

        [Test]
        public void BasicGlobalVariable_LocalDoubleArray_ParseCheck_Expected_Equal() {
            string globalVariableIdentifier = "@my_global_double_array";
            string value = "[double 1.000000e+03, double 2.000000e+00, double 3.400000e+00, double 7.000000e+00, double 5.000000e+01]";
            var global = new LGlobal(new LArrayRef(globalVariableIdentifier, new LValueRef(LType.F64Type(), ""), 5), value) {
                IsConstant = true,
                RuntimePreemptionSpecifier = Enums.LRuntimePreemptionSpecifier.dso_local
            };
            Assert.AreEqual($"{globalVariableIdentifier} = {LKeywords.DsoLocal} {LKeywords.Constant} [5 x double] {value}", global.Parse());
        }
    }
}
