using System.Runtime.Serialization;
using System.Text.Json;
using Domain.Models.API;
using NLog;

namespace Domain.API;

public class HttpHelper
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public static HttpResponseMessage LastCallResponse { get; private set; } = null!;

    public async Task<T> ExecuteCallAsync<T>(Func<Task<HttpResponseMessage>> requestMethod)
    {
        var httpResponseMessage = await requestMethod();
        LogHttpCall(httpResponseMessage);

        var httpResponseData = await httpResponseMessage.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(httpResponseData) ??
               throw new SerializationException(
                   "Response deserialization error. Debug with breakpoints on model's properties for more information.");
    }

    public async Task<HttpResponseMessage> ExecuteCallAsync(Func<Task<HttpResponseMessage>> requestMethod)
    {
        var httpResponseMessage = await requestMethod();
        LogHttpCall(httpResponseMessage);

        return httpResponseMessage;
    }

    private async void LogHttpCall(HttpResponseMessage httpResponseMessage)
    {
        LogRequest(httpResponseMessage.RequestMessage!);
        await LogResponseAsync(httpResponseMessage);
        UpdateLastCallResponse(httpResponseMessage);
    }

    private void LogRequest(HttpRequestMessage request)
    {
        _logger.Info($"{request.Method} request to: \"{request.RequestUri}\".");
    }

    private async Task LogResponseAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorResponseMessage = await response.Content.ReadAsStringAsync();
            var responseWithError = JsonSerializer.Deserialize<ResponseWithErrorMessage>(errorResponseMessage);

            _logger.Info(
                "Error retrieving response.\n" +
                $"Error message: \"{responseWithError!.Message}\".");
        }

        _logger.Info($"Request responded with status code : \"{response.StatusCode}\".");
        _logger.Info(await response.Content.ReadAsStringAsync());
    }

    private void UpdateLastCallResponse(HttpResponseMessage lastCallResponse)
    {
        LastCallResponse = lastCallResponse;
    }
}
