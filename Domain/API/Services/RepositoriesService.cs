using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Models.API;
using Domain.Models.Configuration;

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

    public async Task<GitHubRepository> CreateRepositoryAsync(GitHubRepository repository)
    {
        var settings = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        var body = JsonSerializer.Serialize(repository, settings);

        return await _httpHelper.ExecuteCallAsync<GitHubRepository>(async () =>
            await _httpClient.PostAsync("/user/repos", new StringContent(body)));
    }

    public async Task<IEnumerable<GitHubRepository>> GetAllRepositoriesAsync()
    {
        return await _httpHelper.ExecuteCallAsync<IEnumerable<GitHubRepository>>(async () =>
            await _httpClient.GetAsync("/user/repos"));
    }
    
    public async Task<HttpResponseMessage> DeleteRepository(User user, GitHubRepository repository)
    {
        return await _httpHelper.ExecuteCallAsync(async () =>
            await _httpClient.DeleteAsync($"/repos/{user.Login}/{repository.Name}"));
    }
}
