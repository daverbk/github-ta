using System.Net.Http.Headers;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class ApiTest : IClassFixture<ApiTestFixture>
{
    private ApiTestFixture _apiTestFixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public ApiTest(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async void Test1()
    {
        _apiTestFixture.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        _apiTestFixture.HttpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.2"));
        var response = await _apiTestFixture.HttpClient.GetAsync("https://api.github.com/users/daverbk/repos");
        
        var responseAsString = await response.Content.ReadAsStringAsync();
        
        _testOutputHelper.WriteLine(responseAsString);
    }
}
