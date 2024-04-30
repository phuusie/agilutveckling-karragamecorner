namespace KarraGameCorner.Interfaces;

public interface IHttpClientService
{
    Task<HttpResponseMessage> GetAsync(string uri);
    Task<HttpResponseMessage> PostAsync<T>(string uri, T content);
    Task<HttpResponseMessage> PutAsync<T>(string uri, T content);
    Task<HttpResponseMessage> DeleteAsync(string uri);
    void SetDefaultRequestHeader(string name, string value);
}