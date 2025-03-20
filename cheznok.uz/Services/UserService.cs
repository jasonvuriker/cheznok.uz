using cheznok.uz.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using cheznok.uz.Exceptions;

namespace cheznok.uz.Services;

public interface IUserService
{
    Task<int?> Authenticate(string apiKey);
    Task<string> SignIn(string username, string password);
}

public class UserService : IUserService
{
    private readonly ChesnokContext _context;

    public UserService(ChesnokContext context)
    {
        _context = context;
    }

    public async Task<int?> Authenticate(string apiKey)
    {
        var credentials = Encoding.UTF8
            .GetString(Convert.FromBase64String(apiKey))
            .Split(":");

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Username == credentials[0] && x.PasswordHash == credentials[1]);

        return user?.Id;
    }

    public async Task<string> SignIn(string username, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Username == username && x.PasswordHash == password);

        if (user == null)
        {
            throw new UserNotFoundException(username);
        }
     
        var apiKey = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

        return apiKey;
    }
}
