using System.Net;
using System.Net.Http.Headers;
using Domain.API;
using Domain.Configuration;

namespace Tests.API;

public class ApiTestFixture : IDisposable
{
    public HttpClient Client { get; }

    public HttpHelper Helper { get; }

    public ApiTestFixture()
    {
        Helper = new HttpHelper();
        Client = new HttpClient();

        var authenticationString = "plsvsl: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";
        var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authenticationString));

        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        Client.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.2"));
        Client.BaseAddress = new Uri(Configurator.BaseUrl);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
    }
    
    public void Dispose() => Client.Dispose();
}
