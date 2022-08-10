using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using NLog;

namespace Domain.API;

public class HttpClientExtended
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public HttpClient Client { get; set; }

    public static HttpResponseMessage LastCallResponse { get; private set; } = null!;
    
    public HttpClientExtended(HttpClient client)
    {
        Client = client;
        
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        Client.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.2"));
    }
    
    public async Task<T> ExecuteAsync<T>(Func<Task<HttpResponseMessage>> requestMethod)
    {
        var httpResponseMessage = await requestMethod();
        
        // TODO: Fix code duplicates [17-20, 33-35]
        LogRequest(httpResponseMessage.RequestMessage!);
        LogResponse(httpResponseMessage);
        UpdateLastCallResponse(httpResponseMessage);
            
        var httpResponseData = await httpResponseMessage.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(httpResponseData) ??
               throw new SerializationException(
                   "Response deserialization error. Debug with breakpoints on model's properties for more information.");
    }
    
    public async Task<HttpResponseMessage> ExecuteAsync(Func<Task<HttpResponseMessage>> requestMethod)
    {
        var httpResponseMessage = await requestMethod();
        
        LogRequest(httpResponseMessage.RequestMessage!);
        LogResponse(httpResponseMessage);
        UpdateLastCallResponse(httpResponseMessage);

        return httpResponseMessage;
    }
    
    private void UpdateLastCallResponse(HttpResponseMessage lastCallResponse)
    {
        LastCallResponse = lastCallResponse;
    }
    
    private void LogRequest(HttpRequestMessage request)
    {
        _logger.Info($"{request.Method} request to: {request.RequestUri}");
    }

    private void LogResponse(HttpResponseMessage response)
    {
        _logger.Info(
            $"Error retrieving response. Check inner details for more info. Error message: {response.Headers.Warning}");
        
        _logger.Info($"Request responded with status code : {response.StatusCode}");
        
        _logger.Info(response.Content);
    }
}
