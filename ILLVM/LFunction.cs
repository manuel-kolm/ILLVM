using ILLVM.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILLVM.Internal;
using ILLVM.Types;
using ILLVM.References;
using ILLVM.Const;
using ILLVM.Enums;

namespace ILLVM {
    public class LFunction {
        public readonly string Name;
        public readonly LBaseRef ReturnType;
        public readonly LBaseRef[] Parameters;
        private LRuntimePreemptionSpecifier? _runtimePreemptionSpecifier;

        private readonly IList<LLabelEntry> _labelEntries = new List<LLabelEntry>();
        private int _registeredValueRefs = 0;
        private int _registeredPointerRefs = 0;

        public LRuntimePreemptionSpecifier? RuntimePreemptionSpecifier {
            get => _runtimePreemptionSpecifier;
            set => _runtimePreemptionSpecifier = value;
        }


        public LFunction(string name, LBaseRef returnType, params LBaseRef[] parameters) {
            Name = name;
            ReturnType = returnType;
            Parameters = parameters;
        }

        /// <summary>
        /// Registers <see cref="ILBaseInstr"/> to last label type.
        /// Throws exception if there is none available.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public T Register<T>(T instruction) where T : ILBaseInstr {
            _labelEntries.Last().Append(instruction);
            return instruction;
        }

        /// <summary>
        /// Registers <see cref="ILBaseInstr"/> to the given <see cref="LLabelType"/>.
        /// Throws exception if this label type is not registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="labelType"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public T Register<T>(LLabelType labelType, T instruction) where T : ILBaseInstr {
            bool foundLabel = false;
            foreach (var entry in _labelEntries) {
                if (labelType == entry.Label) {
                    entry.Append(instruction);
                    foundLabel = true;
                }
            }
            if (!foundLabel) {
                throw new Exception("Can't find registered label. label identifier: " + labelType.Identifier);
            }
            return instruction;
        }

        /// <summary>
        /// Registers <see cref="LLabelType"/> at the end of this function.
        /// </summary>
        /// <param name="labelType"></param>
        /// <returns></returns>
        public LLabelType Register(LLabelType labelType) {
            _labelEntries.Add(new LLabelEntry(labelType));
            return labelType;
        }

        /// <summary>
        /// Searches for already registered <see cref="LLabelType"/> with identifier.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public LLabelType GetLabel(string identifier) {
            foreach (var entry in _labelEntries) {
                if (entry.Label.Identifier == identifier) {
                    return entry.Label;
                }
            }
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Returns <see cref="LLabelType"/> with given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LLabelType GetLabel(int index) {
            return _labelEntries[index].Label;
        }

        /// <summary>
        /// Gets next unused value reference identifier.
        /// </summary>
        /// <returns></returns>
        public string GetValueRefIdentifier() {
            return "%v" + _registeredValueRefs++;
        }

        /// <summary>
        /// Gets next unused pointer reference identifier.
        /// </summary>
        /// <returns></returns>
        public string GetPointerRefIdentifier() {
            return "%p" + _registeredPointerRefs++;
        }

        public string Parse() {
            StringBuilder sb = new StringBuilder();
            sb.Append(LKeywords.Define).Append(" ");
            if (RuntimePreemptionSpecifier.HasValue) {
                sb.Append(RuntimePreemptionSpecifier!.Value.Parse()).Append(" ");
            }
            sb.Append(ReturnType.ParseType()).Append(" ").Append(Name);

            // Parameters
            sb.Append("(");
            for (int i = 0; i < Parameters.Length; ++i) {
                if (i > 0) {
                    sb.Append(", ");
                }
                sb.Append(Parameters[i].ParseType());
            }
            sb.AppendLine(") {");

            foreach (var entry in _labelEntries) {
                sb.Append(entry.Parse());
            }

            sb.Append("}");
            return sb.ToString();
        }

        public static LFunction Create(string name, LBaseRef returnType, params LBaseRef[] parameters) {
            return new LFunction(name, returnType, parameters);
        }
    }
}
