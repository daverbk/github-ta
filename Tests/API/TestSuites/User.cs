using System.Net;
using Domain.API;
using Domain.API.Services;
using Xunit;
using Xunit.Abstractions;

namespace Tests.API.TestSuites;

public class User : BaseLoggedApiTest, IClassFixture<ApiTestFixture>
{
    private readonly ApiTestFixture _apiTestFixture;

    private readonly UserService _userService;

    public User(ApiTestFixture apiTestFixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        _apiTestFixture = apiTestFixture;
        _userService = new UserService(_apiTestFixture.Client, _apiTestFixture.Helper);
    }

    [Fact]
    public async void GetUserByLoginTest()
    {
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
        const string userLogin = "daverbk";
        const int expectedUserId = 98875282;
        
        var user = await _userService.GetUserByLoginAsync(userLogin);
        
        var actualUserId = user.Id;
        var actualStatusCode = HttpHelper.LastCallResponse.StatusCode;
        
        Assert.Multiple(() =>
            { 
                Assert.Equal(expectedUserId, actualUserId);
                Assert.Equal(expectedStatusCode, actualStatusCode);  
            });
    }
}
