using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    public enum LLinkageType {
        @private,
        @internal,
        available_externally,
        linkonce,
        weak,
        common,
        appending,
        extern_weak,
        linkonce_odr,
        weak_odr,
        external
    }

    public static class LLinkageTypeExt {
        public static string Parse(this LLinkageType self) {
            return self switch {
                LLinkageType.@private => LKeywords.Private,
                LLinkageType.@internal => LKeywords.Internal,
                LLinkageType.available_externally => LKeywords.AvailableExternally,
                LLinkageType.linkonce => LKeywords.Linkonce,
                LLinkageType.weak => LKeywords.Weak,
                LLinkageType.common => LKeywords.Common,
                LLinkageType.appending => LKeywords.Appending,
                LLinkageType.extern_weak => LKeywords.ExternWeak,
                LLinkageType.linkonce_odr => LKeywords.LinkonceOdr,
                LLinkageType.weak_odr => LKeywords.WeakOdr,
                LLinkageType.external => LKeywords.External,
                _ => throw new NotImplementedException("Unknown operand."),
            };
        }
    }
}
