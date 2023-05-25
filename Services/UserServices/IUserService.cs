namespace shereeni_dotnet.Services.UserServices;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    
    Task<User?> GetUser(int id);
    
    Task<User> CreateUser(User request);

    Task<User> UpdateUser(int id, User request);
    
    Task<List<User>> DeleteUser(int id);
}