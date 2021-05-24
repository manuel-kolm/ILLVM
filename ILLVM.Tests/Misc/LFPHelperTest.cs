using ILLVM.Misc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests.Misc {
    public class LFPHelperTest {
        [Test]
        public void Float_ParseCheck_Ok() {
            Assert.AreEqual("0x4028A4ED40000000", LFPHelper.ConvertFloat2IR(12.322123f));
        }

        [Test]
        public void Float_Negative_ParseCheck_Ok() {
            Assert.AreEqual("0xC028A4ED40000000", LFPHelper.ConvertFloat2IR(-12.322123f));
        }

        [Test]
        public void Float_EvenNumber_ParseCheck_Ok() {
            Assert.AreEqual("1.200000e+01", LFPHelper.ConvertFloat2IR(12f));
        }

        [Test]
        public void Float_NegativeEvenNumber_ParseCheck_Ok() {
            Assert.AreEqual("-1.200000e+01", LFPHelper.ConvertFloat2IR(-12f));
        }

        [Test]
        public void Double_ParseCheck_Ok() {
            Assert.AreEqual("0x4028A4ED4E4C942D", LFPHelper.ConvertDouble2IR(12.322123));
        }

        [Test]
        public void Double_Negative_ParseCheck_Ok() {
            Assert.AreEqual("0xC028A4ED4E4C942D", LFPHelper.ConvertDouble2IR(-12.322123));
        }

        [Test]
        public void Double_EvenNumber_ParseCheck_Ok() {
            Assert.AreEqual("1.200000e+01", LFPHelper.ConvertDouble2IR(12));
        }

        [Test]
        public void Double_NegativeEvenNumber_ParseCheck_Ok() {
            Assert.AreEqual("-1.200000e+01", LFPHelper.ConvertDouble2IR(-12));
        }
    }
}
