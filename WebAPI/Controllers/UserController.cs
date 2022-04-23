using Application.DAOInterface;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private IUserDAO userDao;

    public UserController(IUserDAO userDao)
    {
        this.userDao = userDao;
    }

    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<User>> GetUserAsync([FromRoute] String username)
    {
        try
        {
            User? user = await userDao.GetUserAsync(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    [HttpPost]
    public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
    {
        try
        {
            User userAdded = await userDao.AddUserAsync(user);
            return Ok(userAdded);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
            
        }
    }
}