using System.Net.Http.Json;

namespace ChurchLiveScheduler.sdk;

public abstract class BaseApiClient
{
    private readonly HttpClient _client;
    private readonly string _code;

    protected BaseApiClient(string baseUrl, string code)
    {
        _code = code;
        _client = new() { BaseAddress = new(baseUrl) };
    }

    protected Task<string> GetStringAsync(string uri, CancellationToken cancellationToken = default) =>
        _client.GetStringAsync(uri, cancellationToken);

    protected Task<TResult?> GetFromJsonAsync<TResult>(string uri, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<TResult>(uri, cancellationToken);


    protected Task<TResult?> AuthorizedGetFromJsonAsync<TResult>(string uri, CancellationToken cancellationToken = default) =>
        AuthorizedSend<TResult>(HttpMethod.Get, uri, cancellationToken);

    protected Task<TResult?> AuthorizedPostFromJsonAsync<TResult>(string uri, CancellationToken cancellationToken = default) =>
        AuthorizedSend<TResult>(HttpMethod.Post, uri, cancellationToken);

    protected Task<TResult?> AuthorizedPutFromJsonAsync<TResult>(string uri, CancellationToken cancellationToken = default) =>
        AuthorizedSend<TResult>(HttpMethod.Put, uri, cancellationToken);

    private async Task<TResult?> AuthorizedSend<TResult>(HttpMethod httpMethod, string uri, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(httpMethod, uri);
        request.Headers.Add("x-functions-key", _code);
        var response = await _client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResult>(cancellationToken);
    }
}
