using Bogus;
using Domain.Models.API;

namespace Domain.Fakers;

public sealed class RepositoryFaker : Faker<GitHubRepository>
{
    public RepositoryFaker()
    {
        RuleFor(repository => repository.Name, faker => faker.Name.LastName());
        RuleFor(repository => repository.Description, faker => faker.Company.CatchPhrase());
    }
}
