using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Responses;

[CodeGenType("Responses")]
[CodeGenSuppress("CreateResponseAsync", typeof(ResponseCreationOptions), typeof(AcceptHeaderValue), typeof(CancellationToken))]
[CodeGenSuppress("CreateResponse", typeof(ResponseCreationOptions), typeof(AcceptHeaderValue), typeof(CancellationToken))]
[CodeGenSuppress("GetResponse", typeof(string), typeof(IEnumerable<InternalCreateResponsesRequestIncludable>), typeof(CancellationToken))]
[CodeGenSuppress("GetResponseAsync", typeof(string), typeof(IEnumerable<InternalCreateResponsesRequestIncludable>), typeof(CancellationToken))]
[CodeGenSuppress("GetResponse", typeof(string), typeof(IEnumerable<InternalCreateResponsesRequestIncludable>), typeof(RequestOptions))]
[CodeGenSuppress("GetResponseAsync", typeof(string), typeof(IEnumerable<InternalCreateResponsesRequestIncludable>), typeof(RequestOptions))]
[CodeGenSuppress("ListInputItems", typeof(string), typeof(int?), typeof(OpenAI.VectorStores.VectorStoreCollectionOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("ListInputItemsAsync", typeof(string), typeof(int?), typeof(OpenAI.VectorStores.VectorStoreCollectionOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
public partial class OpenAIResponseClient
{
    private readonly string _model;
    private readonly string _apiVersion;

    // CUSTOM: Added as a convenience.
    /// <summary> Initializes a new instance of <see cref="OpenAIResponseClient"/>. </summary>
    /// <param name="model"> The name of the model to use in requests sent to the service. To learn more about the available models, see <see href="https://platform.openai.com/docs/models"/>. </param>
    /// <param name="apiKey"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="model"/> or <paramref name="apiKey"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
    public OpenAIResponseClient(string model, string apiKey) : this(model, new ApiKeyCredential(apiKey), new OpenAIClientOptions())
    {
    }

    // CUSTOM:
    // - Added `model` parameter.
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    /// <summary> Initializes a new instance of <see cref="OpenAIResponseClient"/>. </summary>
    /// <param name="model"> The name of the model to use in requests sent to the service. To learn more about the available models, see <see href="https://platform.openai.com/docs/models"/>. </param>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="model"/> or <paramref name="credential"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
    public OpenAIResponseClient(string model, ApiKeyCredential credential) : this(model, credential, new OpenAIClientOptions())
    {
    }

    // CUSTOM:
    // - Added `model` parameter.
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    /// <summary> Initializes a new instance of <see cref="OpenAIResponseClient"/>. </summary>
    /// <param name="model"> The name of the model to use in requests sent to the service. To learn more about the available models, see <see href="https://platform.openai.com/docs/models"/>. </param>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="model"/> or <paramref name="credential"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
    public OpenAIResponseClient(string model, ApiKeyCredential credential, OpenAIClientOptions options)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        Argument.AssertNotNull(credential, nameof(credential));
        options ??= new OpenAIClientOptions();

        _model = model;
        Pipeline = OpenAIClient.CreatePipeline(credential, options);
        _endpoint = OpenAIClient.GetEndpoint(options);
        _apiVersion = options.ApiVersion;
    }

    // CUSTOM:
    // - Added `model` parameter.
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    // - Made protected.
    /// <summary> Initializes a new instance of <see cref="OpenAIResponseClient"/>. </summary>
    /// <param name="pipeline"> The HTTP pipeline to send and receive REST requests and responses. </param>
    /// <param name="model"> The name of the model to use in requests sent to the service. To learn more about the available models, see <see href="https://platform.openai.com/docs/models"/>. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="model"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
    protected internal OpenAIResponseClient(ClientPipeline pipeline, string model, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        options ??= new OpenAIClientOptions();

        _model = model;
        Pipeline = pipeline;
        _endpoint = OpenAIClient.GetEndpoint(options);
        _apiVersion = options.ApiVersion;
    }

    public virtual async Task<ClientResult<OpenAIResponse>> CreateResponseAsync(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(inputItems, nameof(inputItems));

        using BinaryContent content = CreatePerCallOptions(options, inputItems, stream: false);
        ClientResult protocolResult = await CreateResponseAsync(content, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        OpenAIResponse convenienceValue = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    public virtual ClientResult<OpenAIResponse> CreateResponse(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(inputItems, nameof(inputItems));

        using BinaryContent content = CreatePerCallOptions(options, inputItems, stream: false);
        ClientResult protocolResult = CreateResponse(content, cancellationToken.ToRequestOptions());
        OpenAIResponse convenienceValue = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<OpenAIResponse>> CreateResponseAsync(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));

        return await CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem(userInputText)],
            options,
            cancellationToken)
                .ConfigureAwait(false);
    }

    public virtual ClientResult<OpenAIResponse> CreateResponse(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));

        return CreateResponse(
            [ResponseItem.CreateUserMessageItem(userInputText)],
            options,
            cancellationToken);
    }

    public virtual AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(inputItems, nameof(inputItems));

        using BinaryContent content = CreatePerCallOptions(options, inputItems, stream: true);
        return new AsyncSseUpdateCollection<StreamingResponseUpdate>(
            async () => await CreateResponseAsync(content, cancellationToken.ToRequestOptions(streaming: true)).ConfigureAwait(false),
            StreamingResponseUpdate.DeserializeStreamingResponseUpdate,
            cancellationToken);
    }

    public virtual CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(inputItems, nameof(inputItems));

        using BinaryContent content = CreatePerCallOptions(options, inputItems, stream: true);
        return new SseUpdateCollection<StreamingResponseUpdate>(
            () => CreateResponse(content, cancellationToken.ToRequestOptions(streaming: true)),
            StreamingResponseUpdate.DeserializeStreamingResponseUpdate,
            cancellationToken);
    }

    public virtual AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));

        return CreateResponseStreamingAsync(
            [ResponseItem.CreateUserMessageItem(userInputText)],
            options,
            cancellationToken);
    }

    public virtual CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));

        return CreateResponseStreaming(
            [ResponseItem.CreateUserMessageItem(userInputText)],
            options,
            cancellationToken);
    }

    public virtual async Task<ClientResult<OpenAIResponse>> GetResponseAsync(string responseId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        ClientResult protocolResult = await GetResponseAsync(responseId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        OpenAIResponse convenienceResult = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceResult, protocolResult.GetRawResponse());
    }

    public virtual ClientResult<OpenAIResponse> GetResponse(string responseId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        ClientResult protocolResult = GetResponse(responseId, cancellationToken.ToRequestOptions());
        OpenAIResponse convenienceResult = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceResult, protocolResult.GetRawResponse());
    }

    public virtual AsyncCollectionResult<ResponseItem> GetResponseInputItemsAsync(string responseId, ResponseItemCollectionOptions options = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        AsyncCollectionResult result = GetResponseInputItemsAsync(responseId, options?.PageSizeLimit, options?.Order?.ToString(), options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions());

        if (result is not AsyncCollectionResult<ResponseItem> responsesItemCollection)
        {
            throw new InvalidOperationException("Failed to cast protocol return type to expected collection type 'AsyncCollectionResult<ResponsesItem>'.");
        }

        return responsesItemCollection;
    }

    public virtual CollectionResult<ResponseItem> GetResponseInputItems(string responseId, ResponseItemCollectionOptions options = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        CollectionResult result = GetResponseInputItems(responseId, options?.PageSizeLimit, options?.Order?.ToString(), options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions());

        if (result is not CollectionResult<ResponseItem> responsesItemCollection)
        {
            throw new InvalidOperationException("Failed to cast protocol return type to expected collection type 'CollectionResult<ResponsesItem>'.");
        }

        return responsesItemCollection;
    }

    public virtual async Task<ClientResult<ResponseDeletionResult>> DeleteResponseAsync(string responseId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        ClientResult result = await DeleteResponseAsync(responseId, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
        return ClientResult.FromValue((ResponseDeletionResult)result, result.GetRawResponse());
    }

    public virtual ClientResult<ResponseDeletionResult> DeleteResponse(string responseId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        ClientResult result = DeleteResponse(responseId, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null);
        return ClientResult.FromValue((ResponseDeletionResult)result, result.GetRawResponse());
    }

    internal virtual ResponseCreationOptions CreatePerCallOptions(ResponseCreationOptions userOptions, IEnumerable<ResponseItem> inputItems, bool stream = false)
    {
        ResponseCreationOptions copiedOptions = userOptions is null
            ? new()
            : userOptions.GetClone();
        copiedOptions.Input = inputItems.ToList();
        copiedOptions.Model = _model;
        if (stream)
        {
            copiedOptions.Stream = true;
        }
        return copiedOptions;
    }
}