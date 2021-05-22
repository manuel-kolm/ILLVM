using ILLVM.Instructions.Terminator;
using ILLVM.References;
using ILLVM.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Instructions.Terminator {
    public class LSwitchTest {
        [Test]
        public void Switch_ParseCheck() {
            LValueRef valueRef = new LValueRef(LType.Int32Type(), "%1");
            LLabelType defaultLabel = new LLabelType("%default");
            LSwitch @switch = new LSwitch(valueRef, defaultLabel);

            @switch.JumpTableDestinations.Add((0, new LLabelType("%one")));
            @switch.JumpTableDestinations.Add((1, new LLabelType("%two")));
            @switch.JumpTableDestinations.Add((2, new LLabelType("%three")));
            @switch.JumpTableDestinations.Add((3, new LLabelType("%four")));

            Assert.AreEqual("switch i32 %1, label %default [ i32 0, label %one\r\ni32 1, label %two\r\ni32 2, label %three\r\ni32 3, label %four ]",
                LHelper.Trim(@switch.ParseInstruction()));
        }

        [Test]
        public void Switch_Unconditional_ParseCheck() {
            LValueRef valueRef = new LValueRef(LType.Int32Type(), "%1");
            LLabelType defaultLabel = new LLabelType("%default");
            LSwitch @switch = new LSwitch(valueRef, defaultLabel); 
            Assert.AreEqual("switch i32 %1, label %default [ ]",
                LHelper.Trim(@switch.ParseInstruction()));
        }
    }
}
