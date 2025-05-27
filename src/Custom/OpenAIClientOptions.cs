using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary> The options to configure the client. </summary>
[CodeGenType("OpenAIClientOptions")]
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    private Uri _endpoint;
    private string _organizationId;
    private string _projectId;
    private string _userAgentApplicationId;
    private string _apiVersion;
    private string _authorizationHeader;
    private string _authorizationApiKeyPrefix;

    /// <summary>
    /// The api version to use for the client. This is used to determine the version of the API that the client will use.
    /// </summary>
    public string ApiVersion
    {
        get => _apiVersion;
        set
        {
            AssertNotFrozen();
            _apiVersion = value;
        }
    }

    /// <summary>
    /// The service endpoint that the client will send requests to. If not set, the default endpoint will be used.
    /// </summary>
    public Uri Endpoint
    {
        get => _endpoint;
        set
        {
            AssertNotFrozen();
            _endpoint = value;
        }
    }

    /// <summary>
    /// Authorization header name.
    /// </summary>
    public string AuthorizationHeader
    {
        get => _authorizationHeader;
        set
        {
            AssertNotFrozen();
            _authorizationHeader = value;
        }
    }

    /// <summary>
    /// The value to use for the <c>Authorization</c> request header. This is typically a prefix followed by an API key.
    /// </summary>
    public string AuthorizationApiKeyPrefix
    {
        get => _authorizationApiKeyPrefix;
        set
        {
            AssertNotFrozen();
            _authorizationApiKeyPrefix = value;
        }
    }

    /// <summary>
    /// The value to use for the <c>OpenAI-Organization</c> request header. Users who belong to multiple organizations
    /// can set this value to specify which organization is used for an API request. Usage from these API requests will
    /// count against the specified organization's quota. If not set, the header will be omitted, and the default
    /// organization will be billed. You can change your default organization in your user settings.
    /// <see href="https://platform.openai.com/docs/guides/production-best-practices/setting-up-your-organization">Learn more</see>.
    /// </summary>
    public string OrganizationId
    {
        get => _organizationId;
        set
        {
            AssertNotFrozen();
            _organizationId = value;
        }
    }

    /// <summary>
    /// The value to use for the <c>OpenAI-Project</c> request header. Users who are accessing their projects through
    /// their legacy user API key can set this value to specify which project is used for an API request. Usage from
    /// these API requests will count as usage for the specified project. If not set, the header will be omitted, and
    /// the default project will be accessed.
    /// </summary>
    public string ProjectId
    {
        get => _projectId;
        set
        {
            AssertNotFrozen();
            _projectId = value;
        }
    }

    /// <summary>
    /// An optional application ID to use as part of the request User-Agent header.
    /// </summary>
    public string UserAgentApplicationId
    {
        get => _userAgentApplicationId;
        set
        {
            AssertNotFrozen();
            _userAgentApplicationId = value;
        }
    }
}
