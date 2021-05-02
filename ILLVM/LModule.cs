using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM {
    public class LModule {
        public readonly string SourceFilename;
        private readonly IList<LGlobal> _globals = new List<LGlobal>();
        private readonly IList<LFunction> _functions = new List<LFunction>();
        private readonly IList<LExternal> _externals = new List<LExternal>();

        public LModule(string sourceFilename) {
            SourceFilename = sourceFilename;
        }

        /// <summary>
        /// Registers global variable / constant. See also <see cref="LGlobal"/>
        /// </summary>
        /// <param name="global"></param>
        /// <returns></returns>
        public LGlobal Register(LGlobal global) {
            _globals.Add(global);
            return global;
        }

        /// <summary>
        /// Registers function. See also <see cref="LFunction"/>
        /// </summary>
        /// <param name="global"></param>
        /// <returns></returns>
        public LFunction Register(LFunction function) {
            _functions.Add(function);
            return function;
        }

        /// <summary>
        /// Registers external functions. See also <see cref="LExternal"/>
        /// </summary>
        /// <param name="global"></param>
        /// <returns></returns>
        public LExternal Register(LExternal external) {
            _externals.Add(external);
            return external;
        }

        public string Parse() {
            StringBuilder sb = new StringBuilder();
            sb.Append(LKeywords.SourceFilename).Append(" = \"").Append(SourceFilename).Append("\"");
            sb.Append("\n\n");

            // Globals / Constants
            foreach (var global in _globals) {
                sb.AppendLine(global.Parse());
            }

            sb.AppendLine();

            // Functions
            foreach (var function in _functions) {
                sb.AppendLine(function.Parse());
                sb.AppendLine();
            }

            // Externals
            foreach (var external in _externals) {
                sb.AppendLine(external.Parse());
            }

            return sb.ToString();
        }
    }
}
