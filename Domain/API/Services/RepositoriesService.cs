using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Models.API;

namespace Domain.API.Services;

public class RepositoriesService
{
    private readonly HttpClient _httpClient;
    private readonly HttpHelper _httpHelper;

    public RepositoriesService(HttpClient httpClient, HttpHelper httpHelper)
    {
        _httpClient = httpClient;
        _httpHelper = httpHelper;
    }
    
    public async Task<GitHubRepository> CreateRepository(GitHubRepository repository)
    {
        var settings = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        
        var body = JsonSerializer.Serialize(repository, settings);
        
        return await _httpHelper.ExecuteCallAsync<GitHubRepository>(async () =>
            await _httpClient.PostAsync("/user/repos", new StringContent(body)));
    }
}
