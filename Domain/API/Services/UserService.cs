using Domain.Configuration;
using Domain.Models.API;

namespace Domain.API.Services;

public class UserService
{
    private readonly HttpClient _httpClient;
    private readonly HttpHelper _httpHelper;

    public UserService(HttpClient httpClient, HttpHelper httpHelper)
    {
        _httpClient = httpClient;
        _httpHelper = httpHelper;
    }

    public async Task<GitHubUser> GetUserByLogin(string userLogin)
    {
        return await _httpHelper.ExecuteCallAsync<GitHubUser>(async () =>
            await _httpClient.GetAsync($"/users/{userLogin}"));
    }
}
