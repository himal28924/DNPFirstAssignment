using Application.DAOInterface;
using Entities.Model;
using JsonDataAccess.FileContext;

namespace JsonDataAccess.DAOImpl;

public class UserDAOImpl:IUserDAO
{
    private  UserFileContext userFileContext;

    public UserDAOImpl(UserFileContext userFileContext)
    {
        this.userFileContext = userFileContext;
    }

    public async Task<User> AddUserAsync(User user)
    {
        
        userFileContext.Users.Add(user);
        await userFileContext.SaveChanges();
        return user;
    }

    public async Task<User?> GetUserAsync(string username)
    {
       return userFileContext.Users.First((user => user.UserName.Equals(username)));
      
    }
}