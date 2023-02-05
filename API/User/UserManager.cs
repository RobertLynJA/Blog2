using API.Data;
using API.Data.Auth0;
using API.Data.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Configuration;
using System.Net;

namespace API.User;

public class UserManager : Interfaces.IUserManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly RestClient _restClient;
    private readonly ILogger<UserManager> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly Auth0Options _auth0Options;

    public UserManager(ILogger<UserManager> logger, IHttpContextAccessor httpContextAccessor, RestClient restClient, IMemoryCache memoryCache, IOptions<Auth0Options> auth0Options)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _auth0Options = auth0Options?.Value ?? throw new ArgumentNullException(nameof(auth0Options));
    }

    public async Task<Auth0User?> GetCurrentUserAsync(CancellationToken cancellationToken = default)
    {
        if (_httpContextAccessor.HttpContext?.User?.Identity?.Name == null)
        {
            _logger.LogError($"{nameof(UserManager)}:{nameof(GetCurrentUserAsync)} User is null.");
            throw new Exception("User is not logged in.");
        }

        var userID = _httpContextAccessor.HttpContext.User.Identity.Name;

        var body = new
        {
            client_id = _auth0Options.APIClientID,
            client_secret = _auth0Options.APIClientSecret,
            audience = _auth0Options.APIAudience,
            grant_type = _auth0Options.APIGrantType
        };

        var authTokenRequest = new RestRequest($"{_auth0Options.APIRootURL ?? throw new ArgumentNullException(nameof(_auth0Options.APIRootURL))}/oauth/token")
            .AddJsonBody(body);

        var authToken = await _restClient.PostAsync<Data.Auth0.Auth0Token>(authTokenRequest, cancellationToken);

        var userRequest = new RestRequest($"{_auth0Options.APIRootURL}/api/v2/users/{WebUtility.UrlEncode(userID)}")
            .AddHeader("authorization", $"Bearer {authToken?.AccessToken ?? throw new ArgumentNullException(nameof(authToken.AccessToken))}");

        var user = await _restClient.GetAsync<Data.Auth0.Auth0User>(userRequest, cancellationToken);

        return user;
    }
}
