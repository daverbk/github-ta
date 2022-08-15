using Tests.API;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class ApiTestSample : BaseLoggedApiTest, IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _apiTestFixture;

    public ApiTestSample(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
    }
    
    [Fact]
    public async void TestSample()
    {
        var response = await _apiTestFixture.Helper.ExecuteCallAsync(async () =>
            await _apiTestFixture.Client.GetAsync("https://api.github.com/users/daverbk"));
        
        await response.Content.ReadAsStringAsync();
    }
}
