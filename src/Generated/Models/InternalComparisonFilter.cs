// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Responses
{
    internal abstract partial class InternalComparisonFilter
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected InternalComparisonFilter(InternalComparisonFilterType @type, string key, BinaryData value)
        {
            Type = @type;
            Key = key;
            Value = value;
        }

        internal InternalComparisonFilter(InternalComparisonFilterType @type, string key, BinaryData value, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            Key = key;
            Value = value;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal InternalComparisonFilterType Type { get; set; }

        public string Key { get; set; }

        public BinaryData Value { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
