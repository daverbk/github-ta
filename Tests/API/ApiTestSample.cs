using Domain.API.Services;
using Domain.Models.API;
using Xunit;
using Xunit.Abstractions;

namespace Tests.API;

public class ApiTestSample : BaseLoggedApiTest, IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _apiTestFixture;

    private readonly UserService _userService;
    private readonly RepositoriesService _repositoryService;

    public ApiTestSample(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
        _userService = new UserService(_apiTestFixture.Client, _apiTestFixture.Helper);
        _repositoryService = new RepositoriesService(_apiTestFixture.Client, _apiTestFixture.Helper);
    }
    
    [Fact]
    public async void TestSample()
    {
        const string userLogin = "daverbk";
        var user = await _userService.GetUserByLogin(userLogin);

        const int expectedUserId = 98875282;
        var actualUserId = user.Id;
        
        Assert.Equal(expectedUserId, actualUserId);

        var newRepository = new GitHubRepository
        {
            Name = "repo55",
            AllowAutoMerge = true,
            DeleteBranchOnMerge = true
        };

        var addedRepo = await _repositoryService.CreateRepository(newRepository);
        
        Assert.Equal(newRepository.Name, addedRepo.Name);
    }
}
