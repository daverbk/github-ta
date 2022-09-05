using Domain.API;
using Domain.API.Services;
using Domain.Models.Configuration;

namespace Domain;

public class TestDataCleanUp
{
    private HttpClient _client;
    private HttpHelper _helper;

    public TestDataCleanUp(HttpClient client, HttpHelper helper)
    {
        _client = client;
        _helper = helper;
    }

    public async Task CleanUpRepositoriesAsync(User user)
    {
        var repositoryService = new RepositoriesService(_client, _helper);
        
        var addedRepos = await repositoryService.GetAllRepositoriesAsync();

        foreach (var repository in addedRepos)
        {
            await repositoryService.DeleteRepositoryAsync(user, repository);
        }
    }
}
