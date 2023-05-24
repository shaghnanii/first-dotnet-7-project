namespace shereeni_dotnet.Services.UserServices;

public interface IUserService
{
    List<User>? GetAllUsers();
    
    User? GetUser(int id);
    
    User CreateUser(User request);

    User UpdateUser(int id, User request);
    
    List<User>? DeleteUser(int id);
}