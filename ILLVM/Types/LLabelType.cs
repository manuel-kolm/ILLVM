using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Types
{
    public class LLabelType : LType
    {
        public readonly string Identifier;

        public LLabelType(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Parse()
        {
            return Identifier + ":";
        }
    }
}
