using ILLVM.Const;
using ILLVM.Enums;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;
using ILLVM.Misc;

namespace ILLVM {
    /// <summary>
    /// Global variables define regions of memory allocated at compilation time instead of run-time.
    /// Global variable definitions must be initialized. Global variables in other translation units can also be declared, in which case they don’t have an initializer.
    /// (Global variables always represents as an pointer reference to their base type.
    /// For instance: this global variable is i32, than it's in real i32 and needs to be loaded within a function code.)
    /// </summary>
    public class LGlobal {
        public readonly LBaseRef TypeRef;
        public readonly string Value;
        private readonly LPointerRef _pointerRef;
        private LLinkageType? _linkageType;
        private LRuntimePreemptionSpecifier? _runtimePreemptionSpecifier;
        private bool? _isConstant;
        private bool? _isExternal;

        public LLinkageType? LinkageType {
            get => _linkageType;
            set {
                _linkageType = value;
            }
        }

        public LRuntimePreemptionSpecifier? RuntimePreemptionSpecifier {
            get => _runtimePreemptionSpecifier;
            set {
                _runtimePreemptionSpecifier = value;
            }
        }

        public bool? IsConstant {
            get => _isConstant;
            set {
                if (_isExternal.HasValue) {
                    throw new Exception("An external global variable can't be constant.");
                }
                _isConstant = value;
            }
        }

        public bool? IsExternal {
            get => _isExternal;
            set {
                if (_isConstant.HasValue) {
                    throw new Exception("An external global variable can't be constant.");
                }
                _isExternal = value;
            }
        }

        public LGlobal(LBaseRef typeRef, string value) {
            TypeRef = typeRef;
            Value = value;

            _pointerRef = new LPointerRef(typeRef, LRefHelper.GetIdentifierOf(TypeRef));
        }

        /// <summary>
        /// Returns <see cref="LPointerRef"/> which can be accessed within a function.
        /// </summary>
        /// <returns></returns>
        public LPointerRef GetPointerRef() {
            return _pointerRef;
        }

        public string Parse() {
            return ParseGlobalValuePointerArray();
        }

        private string ParseGlobalValuePointerArray() {
            StringBuilder sb = new StringBuilder(LRefHelper.GetIdentifierOf(TypeRef));
            sb.Append(" = ");

            if (LinkageType.HasValue) {
                sb.Append(LinkageType.Value.Parse()).Append(" ");
            }
            if (RuntimePreemptionSpecifier.HasValue) {
                sb.Append(RuntimePreemptionSpecifier.Value.Parse()).Append(" ");
            }

            if (IsConstant.HasValue && IsConstant.Value) {
                sb.Append(LKeywords.Constant);
            } else {
                sb.Append(LKeywords.Global);
            }
            sb.Append(" ");
            sb.Append(TypeRef.ParseType()).Append(" ");
            sb.Append(Value);

            return sb.ToString();
        }
    }
}
