using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ILLVM.Misc {
    public static class LFPHelper {
        /// <summary>
        /// Converts floating point value into LLVM IR representation.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertFloat2IR(float value) {
            if (Math.Abs(value) < 999999 && value - (long)value == 0) {
                return ((long)value).ToString("0.000000e+00").Replace(",", ".");
            }
            var data = BitConverter.GetBytes((double)value);
            return "0x" + BitConverter.ToInt64(data).ToString("X");
        }

        /// <summary>
        /// Converts double floating point value into LLVM representation.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertDouble2IR(double value) {
            if (Math.Abs(value) < 999999 && value - (long)value == 0) {
                return ((long)value).ToString("0.000000e+00").Replace(",", ".");
            }
            var data = BitConverter.GetBytes(value);
            return "0x" + BitConverter.ToInt64(data).ToString("X");
        }
    }
}
