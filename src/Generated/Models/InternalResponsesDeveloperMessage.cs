// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI;

namespace OpenAI.Responses
{
    internal partial class InternalResponsesDeveloperMessage : MessageResponseItem
    {
        public InternalResponsesDeveloperMessage(IEnumerable<ResponseContentPart> internalContent) : base(InternalResponsesMessageRole.Developer)
        {
            Argument.AssertNotNull(internalContent, nameof(internalContent));

            InternalContent = internalContent.ToList();
        }

        internal InternalResponsesDeveloperMessage(InternalResponsesItemType @type, string id, IDictionary<string, BinaryData> additionalBinaryDataProperties, MessageStatus? status, InternalResponsesMessageRole internalRole, IList<ResponseContentPart> internalContent) : base(@type, id, additionalBinaryDataProperties, status, internalRole)
        {
            // Plugin customization: ensure initialization of collection
            InternalContent = internalContent ?? new ChangeTrackingList<ResponseContentPart>();
        }
    }
}
