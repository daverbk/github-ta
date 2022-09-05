using System.Text.Json;
using Domain.Models.API;
using Domain.Models.Configuration;

namespace Domain.API.Services;

public class RepositoriesService : BaseApiService
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
        var body = JsonSerializer.Serialize(repository, SerializerOptions);

        return await _httpHelper.ExecuteCallAsync<GitHubRepository>(async () =>
            await _httpClient.PostAsync("/user/repos", new StringContent(body)));
    }

    public async Task<IEnumerable<GitHubRepository>> GetAllRepositoriesAsync()
    {
        return await _httpHelper.ExecuteCallAsync<IEnumerable<GitHubRepository>>(async () =>
            await _httpClient.GetAsync("/user/repos"));
    }

    public async Task<GitHubRepository> GetSpecificRepositoryAsync(string ownerName, string repositoryName)
    {
        return await _httpHelper.ExecuteCallAsync<GitHubRepository>(async () =>
            await _httpClient.GetAsync($"/repos/{ownerName}/{repositoryName}"));
    }

    public async Task<GitHubRepository> UpdateRepositoryAsync(string ownerName, string repositoryName, GitHubRepository repositoryToUpdateWith)
    {
        var body = JsonSerializer.Serialize(repositoryToUpdateWith, SerializerOptions);

        return await _httpHelper.ExecuteCallAsync<GitHubRepository>(async () =>
            await _httpClient.PatchAsync($"/repos/{ownerName}/{repositoryName}", new StringContent(body)));
    }
    
    public async Task<HttpResponseMessage> DeleteRepositoryAsync(User user, GitHubRepository repository)
    {
        return await _httpHelper.ExecuteCallAsync(async () =>
            await _httpClient.DeleteAsync($"/repos/{user.Login}/{repository.Name}"));
    }
}
