using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Const {
    public static class LKeywords {
        public const string SourceFilename = "source_filename";
        public const string Define = "define";
        public const string Alloca = "alloca";
        public const string Align = "align";
        public const string Addrspace = "addrspace";
        public const string Load = "load";
        public const string Volatile = "volatile";
        public const string Store = "store";
        public const string Atomic = "atomic";
        public const string Cmpxchg = "cmpxchg";
        public const string Getelementptr = "getelementptr";
        public const string Br = "br";
        public const string Label = "label";
        public const string Ret = "ret";
        public const string Void = "void";
        public const string Global = "global";
        public const string Constant = "constant";
        public const string Private = "private";
        public const string Internal = "internal";
        public const string AvailableExternally = "available_externally";
        public const string Linkonce = "linkonce";
        public const string Weak = "weak";
        public const string Common = "common";
        public const string Appending = "appending";
        public const string ExternWeak = "extern_weak";
        public const string LinkonceOdr = "linkonce_odr";
        public const string WeakOdr = "weak_odr";
        public const string External = "external";
        public const string DsoPreemptable = "dso_preemptable";
        public const string DsoLocal = "dso_local";
        public const string Inbounds = "inbounds";
        public const string Inrange = "inrange";
        public const string Fneg = "fneg";


        public const string Xchg = "xchg";
        public const string Add = "add";
        public const string Sub = "sub";
        public const string And = "and";
        public const string Nand = "nand";
        public const string Or = "or";
        public const string Xor = "xor";
        public const string Max = "max";
        public const string Min = "min";
        public const string Umax = "umax";
        public const string Umin = "umin";
        public const string Fadd = "fadd";
        public const string Fsub = "fsub";

        public static readonly List<string> AllKeywords = new List<string>()
        {
            Alloca, Align, Addrspace, Load, Volatile, Store
        };
    }
}
