using System.Text.Json.Serialization;
using Mysqlx.Datatypes;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty)
    {
    }
    
    public int Id { get; }
    
    public string Username { get; private set; } = username;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

}