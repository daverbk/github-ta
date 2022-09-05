using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.API.Services;

public class BaseApiService
{
    public readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };
}
