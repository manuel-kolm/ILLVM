using ILLVM.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Enums {
    public enum LOrdering {
        /// <summary>
        /// The set of values that can be read is governed by the happens-before partial order.
        /// A value cannot be read unless some operation wrote it.
        /// This is intended to provide a guarantee strong enough to model Java’s non-volatile shared variables. This ordering cannot be specified for read-modify-write operations; it is not strong enough to make them atomic in any interesting way.
        /// </summary>
        unordered,
        /// <summary>
        /// In addition to the guarantees of unordered, there is a single total order for modifications by monotonic operations on each address. All modification orders must be compatible with the happens-before order. There is no guarantee that the modification orders can be combined to a global total order for the whole program (and this often will not be possible).
        /// The read in an atomic read-modify-write operation (cmpxchg and atomicrmw) reads the value in the modification order immediately before the value it writes.
        /// If one atomic read happens before another atomic read of the same address, the later read must see the same value or a later value in the address’s modification order.
        /// This disallows reordering of monotonic (or stronger) operations on the same address. If an address is written monotonic-ally by one thread, and other threads monotonic-ally read that address repeatedly, the other threads must eventually see the write.
        /// This corresponds to the C++0x/C1x memory_order_relaxed.
        /// </summary>
        monotonic,
        /// <summary>
        /// In addition to the guarantees of monotonic, a synchronizes-with edge may be formed with a release operation. This is intended to model C++’s memory_order_acquire.
        /// </summary>
        acquire,
        /// <summary>
        /// In addition to the guarantees of monotonic, if this operation writes a value which is subsequently read by an acquire operation, it synchronizes-with that operation.
        /// (This isn’t a complete description; see the C++0x definition of a release sequence.) This corresponds to the C++0x/C1x memory_order_release.
        /// </summary>
        release,
        /// <summary>
        /// Acts as both an acquire and release operation on its address. This corresponds to the C++0x/C1x memory_order_acq_rel.
        /// </summary>
        acq_rel,
        /// <summary>
        /// In addition to the guarantees of acq_rel (acquire for an operation that only reads, release for an operation that only writes), there is a global total order on all sequentially-consistent operations on all addresses, which is consistent with the happens-before partial order and with the modification orders of all the affected addresses.
        /// Each sequentially-consistent read sees the last preceding write to the same address in this global order. This corresponds to the C++0x/C1x memory_order_seq_cst and Java volatile.
        /// </summary>
        seq_cst
    }

    public static class LOrderingExt {
        public static string Parse(this LOrdering self) {
            return self switch {
                LOrdering.unordered => LKeywords.Unordered,
                LOrdering.monotonic => LKeywords.Monotonic,
                LOrdering.acquire => LKeywords.Acquire,
                LOrdering.release => LKeywords.Release,
                LOrdering.acq_rel => LKeywords.Acq_rel,
                LOrdering.seq_cst => LKeywords.Seq_cst,
                _ => throw new NotImplementedException("Unknown operand."),
            };
        }
    }
}
