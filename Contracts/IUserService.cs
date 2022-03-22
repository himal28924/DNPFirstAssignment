using Entities.Model;

namespace Contracts;

public interface IUserService
{
    public Task<User> AddUserAsync(User user);
    public Task<User?> GetUserAsync(string username);
}