using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Tests {
    public static class LHelper {
        /// <summary>
        /// Removes whitespace at the begin and end of every line.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Trim(string str) {
            StringBuilder sb = new StringBuilder();
            string[] lines = str.Split(Environment.NewLine);

            for (int i = 0; i < lines.Length; ++i) {
                lines[i] = lines[i].Trim();
                
                if (i != 0) {
                    sb.AppendLine();
                }
                sb.Append(lines[i]);
            }

            return sb.ToString();
        }
    }
}
