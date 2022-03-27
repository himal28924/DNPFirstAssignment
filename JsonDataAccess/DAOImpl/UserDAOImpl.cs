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

        if (userFileContext.IsUsernameAvailable(user.UserName))
        {
            userFileContext.Users.Add(user);
            await userFileContext.SaveChanges();
            return user;
        }
        else
        {
            user.UserName = null;
            return user;
        }

    }

    public async Task<User?> GetUserAsync(string username)
    {
       return userFileContext.Users.First((user => user.UserName.Equals(username)));
      
    }
}