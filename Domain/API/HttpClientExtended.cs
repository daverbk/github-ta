using System.Runtime.Serialization;
using System.Text.Json;
using NLog;

namespace Domain.API;

public class HttpClientExtended
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public static HttpResponseMessage LastCallResponse { get; private set; } = null!;

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
        _logger.Debug($"{request.Method} request to: {request.RequestUri}");
    }

    private void LogResponse(HttpResponseMessage response)
    {
        _logger.Error(
            $"Error retrieving response. Check inner details for more info. Error message: {response.Headers.Warning}");
        
        _logger.Debug($"Request responded with status code : {response.StatusCode}");
        
        _logger.Debug(response.Content);
    }
}
