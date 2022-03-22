using Entities.Model;

namespace Application.DAOInterface;

public interface IUserDAO
{
    public Task<User> AddUserAsync(User user);
    public Task<User?> GetUserAsync(string username);
}