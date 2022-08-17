using System.Net;
using Domain.API;
using Domain.API.Services;
using Xunit;
using Xunit.Abstractions;

namespace Tests.API.TestSuites;

public class Repository : BaseLoggedApiTest, IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _apiTestFixture;
    private readonly RepositoriesService _repositoryService;

    public Repository(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
        _repositoryService = new RepositoriesService(_apiTestFixture.Client, _apiTestFixture.Helper);
    }
    
    [Fact]
    public async void CreateNewRepositoryTest()
    {
        const HttpStatusCode expectedStatusCode = HttpStatusCode.Created;

        var newRepository = _apiTestFixture.RepositoryFaker.Generate();

        var addedRepo = await _repositoryService.CreateRepositoryAsync(newRepository);
        var actualStatusCode = HttpHelper.LastCallResponse.StatusCode;

        Assert.Equal(newRepository.Name, addedRepo.Name);
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
    
    [Fact]
    public async void GetAllRepositoriesTest()
    {
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
        var addedRepos = await _repositoryService.GetAllRepositoriesAsync();

        var actualStatusCode = HttpHelper.LastCallResponse.StatusCode;

        Assert.NotEmpty(addedRepos);
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
}
