using ILLVM.Const;
using ILLVM.References;
using ILLVM.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILLVM.Instructions.Terminator {
    public abstract class LBr : ILBaseInstr {
        public bool IsConditional => this is LConditionalBr;

        public abstract string ParseInstruction();
    }

    public class LConditionalBr : LBr {
        public readonly LValueRef Condition;
        public readonly LLabelType IfTrueLabel;
        public readonly LLabelType IfFalseLabel;

        public LConditionalBr(LValueRef condition, LLabelType ifTrueLabel, LLabelType ifFalseLabel) {
            if (!condition.Type.IsPrimitiveType() || condition.Type.CheckedCast<LPrimitiveType>().Type != LPrimitiveTypes.@bool) {
                throw new Exception("Condition must be from type i1. Actual type: " + condition.ParseType());
            }

            Condition = condition;
            IfTrueLabel = ifTrueLabel;
            IfFalseLabel = ifFalseLabel;
        }

        public override string ParseInstruction() {
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(LKeywords.Br).Append(" i1 ");
            sb.Append(Condition.ValueOrIdentifier).Append(", ");
            sb.Append(LKeywords.Label).Append(" ").Append(IfTrueLabel.Identifier);
            sb.Append(", ").Append(LKeywords.Label).Append(" ").Append(IfFalseLabel.Identifier);
            return sb.ToString();
        }
    }

    public class LUnconditionalBr : LBr {
        public LLabelType DestinationLabel;

        public LUnconditionalBr(LLabelType destinationLabel) {
            DestinationLabel = destinationLabel;
        }

        public override string ParseInstruction() {
            return $"\t{LKeywords.Br} {LKeywords.Label} " + DestinationLabel.Identifier;
        }
    }
}
