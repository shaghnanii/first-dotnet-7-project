namespace shereeni_dotnet.Services.UserServices;

public class UserService : IUserService
{
    private static List<User> _users = new List<User>
    {
        new User
        {
            Id = 1,
            Name = "Shakil Ahmad",
            Email = "shakilahmad@yopmail.com",
            Password = "something"
        },
        new User
        {
            Id = 2,
            Name = "Maria Khan",
            Email = "mariya@yopmail.com",
            Password = "something"
        },
        new User()
        {
            Id = 3,
            Name = "Test User",
            Email = "teste@yopmail.com",
            Password = "somethingNew"
        }
    };
    
    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUser(int id)
    {
        var user = _users.Find(x => x.Id == id);
        return user ?? null;
    }

    public User CreateUser(User request)
    {
        _users.Add(request);
        return request;
    }

    public User UpdateUser(int id, User request)
    {
        var user = _users.Find(x => x.Id == id);
        if (user is null)
            return null;
        user.Name = request.Name;
        user.Email = request.Email;
        user.Password = request.Password;
        
        return user;
    }

    public List<User> DeleteUser(int id)
    {
        var user = _users.Find(x => x.Id == id);
        if (user is null)
            return null;

        _users.Remove(user);
        
        return _users;
    }
}