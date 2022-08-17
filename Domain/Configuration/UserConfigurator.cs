using System.Text.Json;
using Domain.Models.Configuration;

namespace Domain.Configuration;

public static class UserConfigurator
{
    private const string UserConfigurationFileName = "userData.json";
    private const string PlsvslUserLogin = "plsvsl";
    
    private static IEnumerable<User> Users { get; }

    public static User PlsvslUser => GetSpecificUser(PlsvslUserLogin); 
    
    static UserConfigurator()
    {
        var fileContent = File.ReadAllText(UserConfigurationFileName);
        
        Users = JsonSerializer.Deserialize<User[]>(fileContent) 
                ?? throw new InvalidDataException("Config file \"userData.json\" is empty.");
    }

    private static User GetSpecificUser(string userLogin)
    {
        return Users.First(user => user.Login == userLogin);
    }
}
