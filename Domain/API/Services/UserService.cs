using System.Text.Json;
using Domain.Models.API;

namespace Domain.API.Services;

public class UserService : BaseApiService
{
    private readonly HttpClient _httpClient;
    private readonly HttpHelper _httpHelper;

    public UserService(HttpClient httpClient, HttpHelper httpHelper)
    {
        _httpClient = httpClient;
        _httpHelper = httpHelper;
    }

    public async Task<GitHubUser> GetUserByLoginAsync(string userLogin)
    {
        return await _httpHelper.ExecuteCallAsync<GitHubUser>(async () =>
            await _httpClient.GetAsync($"/users/{userLogin}"));
    }
    
    public async Task<GitHubUser> UpdateAuthenticatedUserAsync(GitHubUser userToUpdateWith)
    {
        var body = JsonSerializer.Serialize(userToUpdateWith, SerializerOptions);
        
        return await _httpHelper.ExecuteCallAsync<GitHubUser>(async () =>
            await _httpClient.PatchAsync("/user", new StringContent(body)));
    }
}
