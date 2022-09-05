using Domain;
using Domain.API;
using Domain.Configuration;
using Domain.Fakers;

namespace Tests.API;

public class ApiTestFixture : IDisposable
{
    public HttpClient Client { get; }

    public HttpHelper Helper { get; }

    public RepositoryFaker RepositoryFaker { get; }

    public ApiTestFixture()
    {
        RepositoryFaker = new RepositoryFaker();

        Helper = new HttpHelper();
        Client = new HttpClientFactory().InitializeDefaultClient();
    }

    public async void Dispose()
    {
        await new TestDataCleanUp(Client, Helper).CleanUpRepositoriesAsync(UserConfigurator.PlsvslUser);
        Client.Dispose();
    }
}
