using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using shereeni_dotnet.Models.DTO;
using shereeni_dotnet.Models.DTO.User;

namespace shereeni_dotnet.Services.UserServices;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    // since we are using async Function, so we need to use the return type to task
    public async Task<List<User>> GetAllUsers()
    {
        var users = await _context.Users
            .Include(post => post.Posts)
            .ThenInclude(comments => comments.Comments)
            .ToListAsync();

        return users;
    }

    public async Task<User?> GetUser(int id)
    {
        var result = await _context.Users
            .Include(_ => _.Posts)
            .ThenInclude(_ => _.Comments)
            .Where(_ => _.Id == id)
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<User?> CreateUser(UserDTO request)
    {
        var newUser = new User();
    
        var userDtoProperties = typeof(UserDTO).GetProperties();
        var userProperties = typeof(User).GetProperties();
    
        foreach (var userDtoProperty in userDtoProperties)
        {
            var userProperty = userProperties.FirstOrDefault(p => p.Name == userDtoProperty.Name);
            if (userProperty != null)
            {
                var value = userDtoProperty.GetValue(request);
                userProperty.SetValue(newUser, value);
            }
        }
    
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        
        return newUser;
    }

 
    public async Task<User> UpdateUser(int id, UserDTO request)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;
        
        // user.Name = request.Name;
        // user.Email = request.Email;
        // user.Password = request.Password;
        // await _context.SaveChangesAsync();
        
        var propertiesToUpdate = typeof(UserDTO).GetProperties();
        foreach (var property in propertiesToUpdate)
        {
            var requestValue = property.GetValue(request);
            if (requestValue != null)
            {
                property.SetValue(user, requestValue);
            }
        }
        
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<List<User>> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return null;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return await _context.Users.ToListAsync();
    }
}