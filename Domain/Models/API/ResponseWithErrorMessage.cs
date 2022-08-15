using System.Text.Json.Serialization;

namespace Domain.Models.API;

public class ResponseWithErrorMessage
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
