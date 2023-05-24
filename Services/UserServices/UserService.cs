using Microsoft.EntityFrameworkCore;

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
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user ?? null;
    }

    public async Task<User> CreateUser(User request)
    {
        _context.Users.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<User> UpdateUser(int id, User request)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return null;
        user.Name = request.Name;
        user.Email = request.Email;
        user.Password = request.Password;
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