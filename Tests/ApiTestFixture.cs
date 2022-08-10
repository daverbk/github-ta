using Domain.API;

namespace Tests;

public class ApiTestFixture : IDisposable
{
    public HttpClientExtended HttpClientExtended { get; set; }

    public ApiTestFixture()
    {
        HttpClientExtended = new HttpClientExtended(new HttpClient());
    }

    public void Dispose()
    {
        HttpClientExtended.Client.Dispose();
    }
}
