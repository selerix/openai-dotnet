// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Responses
{
    public partial class StreamingResponseContentPartDoneUpdate : StreamingResponseUpdate
    {
        internal StreamingResponseContentPartDoneUpdate(string itemId, int outputIndex, int contentIndex, ResponseContentPart part) : base(InternalResponsesResponseStreamEventType.ResponseContentPartDone)
        {
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Part = part;
        }

        internal StreamingResponseContentPartDoneUpdate(InternalResponsesResponseStreamEventType @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, string itemId, int outputIndex, int contentIndex, ResponseContentPart part) : base(@type, additionalBinaryDataProperties)
        {
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Part = part;
        }

        public string ItemId { get; }

        public int OutputIndex { get; }

        public int ContentIndex { get; }
    }
}
