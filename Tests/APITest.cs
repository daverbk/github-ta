using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class ApiTest : IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _apiTestFixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public ApiTest(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async void Test1()
    {
        // TODO: Response is not logged. 
        
        var response = await _apiTestFixture.HttpClientExtended.ExecuteAsync(async () => await _apiTestFixture.HttpClientExtended.Client.GetAsync("https://api.github.com/users/daverbk/repos"));
        
        var responseAsString = await response.Content.ReadAsStringAsync();
        
        _testOutputHelper.WriteLine(responseAsString);
    }
}
