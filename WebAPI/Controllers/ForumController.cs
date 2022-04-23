using Application.DAOInterface;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ForumController:ControllerBase
{

    private IForumDAO forumDao;

    public ForumController(IForumDAO forumDao)
    {
        this.forumDao = forumDao;
    }

    // adding sub forum 
    [HttpPost]
    [Route("{id}")]
    public async Task<ActionResult<Forum>> AddForumAsync([FromRoute] int id,[FromBody]Forum forum)
    {
        try
        {
            Forum forumAdded = await forumDao.AddForumAsync(id, forum);
            return Created($"/AllForums/{id}",forumAdded);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //adding main forum
    [HttpPost]
    public async Task<ActionResult<MainForum>> AddMainForumAsync([FromBody] MainForum mainForum)
    {
      
        try
        {
            MainForum forumAdded = await forumDao.AddMainForumAsync( mainForum);
            return Created($"/AllForums/{forumAdded.MainForumId}",forumAdded);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<MainForum>> GetMainForumAsync([FromRoute]int id)
    {
        try
        {
            
            MainForum forumReturned =  forumDao.GetMainForumAsync( id);
            
            return Ok(forumReturned);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet] 
    public async Task<ActionResult<ICollection<MainForum>>> GetAllForum()
    {
        try
        {
            ICollection<MainForum>? forumReturned = await forumDao.GetAllForums();
            return Ok(forumReturned);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    
    
    
    

    


}