// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal readonly partial struct InternalFineTuningJobEventType : IEquatable<InternalFineTuningJobEventType>
    {
        private readonly string _value;
        private const string MessageValue = "message";
        private const string MetricsValue = "metrics";

        public InternalFineTuningJobEventType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalFineTuningJobEventType Message { get; } = new InternalFineTuningJobEventType(MessageValue);

        public static InternalFineTuningJobEventType Metrics { get; } = new InternalFineTuningJobEventType(MetricsValue);

        public static bool operator ==(InternalFineTuningJobEventType left, InternalFineTuningJobEventType right) => left.Equals(right);

        public static bool operator !=(InternalFineTuningJobEventType left, InternalFineTuningJobEventType right) => !left.Equals(right);

        public static implicit operator InternalFineTuningJobEventType(string value) => new InternalFineTuningJobEventType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalFineTuningJobEventType other && Equals(other);

        public bool Equals(InternalFineTuningJobEventType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
