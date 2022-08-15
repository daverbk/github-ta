using Domain.Configuration;
using Xunit.Abstractions;

namespace Tests.API;

public abstract class BaseLoggedApiTest
{
    protected BaseLoggedApiTest(ITestOutputHelper testOutputHelper)
    {
        LoggerForXunitSetUp.SetUp(testOutputHelper);
    }
}
