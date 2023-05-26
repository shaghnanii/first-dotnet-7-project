using shereeni_dotnet.Models.DTO;
using shereeni_dotnet.Models.DTO.User;

namespace shereeni_dotnet.Services.UserServices;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    
    Task<User?> GetUser(int id);
    
    Task<User?> CreateUser(UserDTO request);

    Task<User> UpdateUser(int id, UserDTO request);
    
    Task<List<User>> DeleteUser(int id);
}