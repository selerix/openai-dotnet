// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Responses
{
    public partial class StreamingResponseOutputItemAddedUpdate : IJsonModel<StreamingResponseOutputItemAddedUpdate>
    {
        internal StreamingResponseOutputItemAddedUpdate()
        {
        }

        void IJsonModel<StreamingResponseOutputItemAddedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingResponseOutputItemAddedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StreamingResponseOutputItemAddedUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("output_index") != true)
            {
                writer.WritePropertyName("output_index"u8);
                writer.WriteNumberValue(OutputIndex);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("item") != true)
            {
                writer.WritePropertyName("item"u8);
                writer.WriteObjectValue(Item, options);
            }
        }

        StreamingResponseOutputItemAddedUpdate IJsonModel<StreamingResponseOutputItemAddedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (StreamingResponseOutputItemAddedUpdate)JsonModelCreateCore(ref reader, options);

        protected override StreamingResponseUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingResponseOutputItemAddedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StreamingResponseOutputItemAddedUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStreamingResponseOutputItemAddedUpdate(document.RootElement, options);
        }

        internal static StreamingResponseOutputItemAddedUpdate DeserializeStreamingResponseOutputItemAddedUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalResponsesResponseStreamEventType @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            int outputIndex = default;
            ResponseItem item = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalResponsesResponseStreamEventType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("output_index"u8))
                {
                    outputIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("item"u8))
                {
                    item = ResponseItem.DeserializeResponseItem(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new StreamingResponseOutputItemAddedUpdate(@type, additionalBinaryDataProperties, outputIndex, item);
        }

        BinaryData IPersistableModel<StreamingResponseOutputItemAddedUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingResponseOutputItemAddedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(StreamingResponseOutputItemAddedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        StreamingResponseOutputItemAddedUpdate IPersistableModel<StreamingResponseOutputItemAddedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (StreamingResponseOutputItemAddedUpdate)PersistableModelCreateCore(data, options);

        protected override StreamingResponseUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingResponseOutputItemAddedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeStreamingResponseOutputItemAddedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(StreamingResponseOutputItemAddedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<StreamingResponseOutputItemAddedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(StreamingResponseOutputItemAddedUpdate streamingResponseOutputItemAddedUpdate)
        {
            if (streamingResponseOutputItemAddedUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(streamingResponseOutputItemAddedUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator StreamingResponseOutputItemAddedUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeStreamingResponseOutputItemAddedUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
