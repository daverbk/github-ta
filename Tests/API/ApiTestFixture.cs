using System.Net.Http.Headers;
using Domain.API;

namespace Tests.API;

public class ApiTestFixture : IDisposable
{
    public HttpClient Client { get; }

    public HttpHelper Helper { get; }

    public ApiTestFixture()
    {
        Helper = new HttpHelper();
        Client = new HttpClient();

        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        Client.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.2"));
    }
    
    public void Dispose() => Client.Dispose();
}
