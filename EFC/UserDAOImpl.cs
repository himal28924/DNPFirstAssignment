using Application.DAOInterface;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class UserDAOImpl:IUserDAO
{
    private DAOContext daoContext;

    public UserDAOImpl(DAOContext daoContext)
    {
        this.daoContext = daoContext;
    }

    public Task<User> AddUserAsync(User user)
    {
        User addedUser = daoContext.Users.AddAsync(user).Result.Entity;
        Console.WriteLine("Over here in adduseraysnc dao impl");
        daoContext.SaveChangesAsync();
        return Task.FromResult(addedUser);
    }

    public Task<User?> GetUserAsync(string username)
    {
        User returnedUser = daoContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(username)).Result;
        return Task.FromResult(returnedUser);
    }
}