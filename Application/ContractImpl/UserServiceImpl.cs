
using Application.DAOInterface;
using Contracts;
using Entities.Model;

namespace Application.ContractImpl;

public class UserServiceImpl:IUserService
{

private IUserDAO userDao;

public UserServiceImpl(IUserDAO userDao)
{
    this.userDao = userDao;
}

public async Task<User> AddUserAsync(User user)
{

 
    await userDao.AddUserAsync(user);
    return user;
}

public  async Task<User?> GetUserAsync(string username)
{
    User user = await userDao.GetUserAsync(username);
    return user;
    
}
}

