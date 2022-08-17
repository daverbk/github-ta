using System.Net.Http.Headers;
using Domain.Configuration;

namespace Domain.API;

public class HttpClientFactory
{
    public HttpClient InitializeDefaultClient()
    {
        var httpClient = new HttpClient();
        
        var authenticationString = $"{UserConfigurator.PlsvslUser.Login}:{UserConfigurator.PlsvslUser.Token}";
        var base64EncodedAuthenticationString = EncodeAuthenticationString(authenticationString);

        httpClient.BaseAddress = new Uri(Configurator.BaseUrl);
        
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        httpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.2"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

        return httpClient;
    }

    private string EncodeAuthenticationString(string authenticationString)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authenticationString));
    }
}
