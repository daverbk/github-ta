using Domain.API;

namespace Tests;

public class ApiTestFixture : IDisposable
{
    public HttpClientExtended HttpClientExtended { get; set; }

    public HttpClient HttpClient { get; set; }
    
    public ApiTestFixture()
    {
        HttpClient = new HttpClient();
        HttpClientExtended = new HttpClientExtended();
    }

    public void Dispose()
    {
        HttpClient.Dispose();
    }
}
