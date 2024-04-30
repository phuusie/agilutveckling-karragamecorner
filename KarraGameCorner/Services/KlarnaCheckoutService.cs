using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using KarraGameCorner.Klarna;
using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class KlarnaCheckoutService(HttpClient httpClient)
{
    private readonly string? _klarnaApiKey = Environment.GetEnvironmentVariable("KlarnaAPIKey"); // The API key is stored in an environment variable
    private readonly string? _klarnaApiPassword = Environment.GetEnvironmentVariable("KlarnaAPIKeyPassword"); // The API key password is stored in an environment variable


    public async Task<KlarnaCreateOrderResponseDto> CreateKlarnaCheckoutSession(KlarnaCreateOrderRequestDto order)
    {
        // Set the base URL and the authentication header
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_klarnaApiKey}:{_klarnaApiPassword}"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        // Make the API call to create the Klarna checkout session
        var response = await httpClient.PostAsJsonAsync("https://api.playground.klarna.com/checkout/v3/orders", order);
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to create Klarna checkout session. Status: {response.StatusCode}, Body: {errorResponse}");
            throw new Exception($"API call failed: {response.StatusCode}");
        }
        // Parse the response and return the HTML snippet
        return await response.Content.ReadFromJsonAsync<KlarnaCreateOrderResponseDto>();
    }

    //Går att använda för att hämta order från klarna men använder inte för att jag inte löst Klarnas confirmation_url
    public async Task<KlarnaReadOrderResponseDto> ReadKlarnaOrder(string orderId)
    {
        // Set the base URL and the authentication header
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_klarnaApiKey}:{_klarnaApiPassword}"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        // Make the API call to read the Klarna order
        var response = await httpClient.GetAsync($"https://api.playground.klarna.com/checkout/v3/orders/{orderId}");

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to read Klarna order. Status: {response.StatusCode}, Body: {errorResponse}");
            throw new Exception($"API call failed: {response.StatusCode}");
        }

        // Parse the response and return the order object
        var responseData = await response.Content.ReadAsStringAsync();
        var order = JsonConvert.DeserializeObject<KlarnaReadOrderResponseDto>(responseData);
        return order;
    }
}