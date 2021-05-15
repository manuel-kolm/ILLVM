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
        public const string Nuw = "nuw";
        public const string Nsw = "nsw";
        public const string Mul = "mul";
        public const string Fmul = "fmul";
        public const string Udiv = "udiv";
        public const string Exact = "exact";
        public const string Sdiv = "sdiv";
        public const string Fdiv = "fdiv";
        public const string Urem = "urem";
        public const string Srem = "srem";
        public const string Frem = "frem";
        public const string Shl = "shl";
        public const string Lshr = "lshr";
        public const string Icmp = "icmp";
        public const string Fcmp = "fcmp";
        public const string False = "false";
        public const string True = "true";

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
        public const string Ashr = "ashr";

        public const string Eq = "eq";
        public const string Ne = "ne";
        public const string Ugt = "ugt";
        public const string Uge = "uge";
        public const string Ule = "ule";
        public const string Ult = "ult";
        public const string Sgt = "sgt";
        public const string Sge = "sge";
        public const string Slt = "slt";
        public const string Sle = "sle";

        public const string Oeq = "oeq";
        public const string Ogt = "ogt";
        public const string Oge = "oge";
        public const string Olt = "olt";
        public const string Ole = "ole";
        public const string One = "one";
        public const string Ord = "ord";
        public const string Ueq = "ueq";
        public const string Une = "une";
        public const string Uno = "uno";

        public static readonly List<string> AllKeywords = new List<string>()
        {
            Alloca, Align, Addrspace, Load, Volatile, Store
        };
    }
}
