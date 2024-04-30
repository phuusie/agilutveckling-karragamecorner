using KarraGameCorner.Interfaces;

namespace KarraGameCorner.Services;

public class HttClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _httpClient;

    private string client = Environment.GetEnvironmentVariable("SQLConnectionString");

    public HttClientService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _httpClient = _clientFactory.CreateClient(client);
    }

    public Task<HttpResponseMessage> GetAsync(string uri)
    {
        return _httpClient.GetAsync(uri);
    }

    public Task<HttpResponseMessage> PostAsync<T>(string uri, T content)
    {
        return _httpClient.PostAsJsonAsync(uri, content);
    }

    public Task<HttpResponseMessage> PutAsync<T>(string uri, T content)
    {
        return _httpClient.PutAsJsonAsync(uri, content);
    }

    public Task<HttpResponseMessage> DeleteAsync(string uri)
    {
        return _httpClient.DeleteAsync(uri);
    }

    public void SetDefaultRequestHeader(string name, string value)
    {
        _httpClient.DefaultRequestHeaders.Add(name, value);
    }
}