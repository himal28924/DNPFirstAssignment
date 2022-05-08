using Application.DAOInterface;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFC;

public class ForumDAOImpl : IForumDAO
{
    private DAOContext daoContext;

    public ForumDAOImpl(DAOContext daoContext)
    {
        this.daoContext = daoContext;
    }

    public async Task<Forum> AddForumAsync(int id, Forum forum)
    {
        forum.MainForumId = id;
        Forum addedForum = daoContext.Forums.AddAsync(forum).Result.Entity;
        await daoContext.SaveChangesAsync();
        return addedForum;
        
        
    }

    public async Task<MainForum> AddMainForumAsync(MainForum mainForum)
    {
        mainForum.NoOfViews = 0;
        MainForum addedMainForum = daoContext.MainForums.AddAsync(mainForum).Result.Entity;
        await daoContext.SaveChangesAsync();
        return addedMainForum;
    }

    public async Task<List<Forum>> GetSubForumByMainForumId(int id)
    {
        increaseNoOfViews(id);
        List<Forum> forums =  daoContext.Forums.Where(forum => forum.MainForumId.Equals(id)).ToList();
        if (forums == null)
        {
            forums = new List<Forum>();
        }
        return forums;
    }

    private async Task increaseNoOfViews(int id)
    {
         daoContext.MainForums.FirstOrDefaultAsync(forum => forum.MainForumId.Equals(id)).Result.NoOfViews += 1;
    }

    public async Task<ICollection<MainForum>> GetAllForums()
    {
        ICollection<MainForum> mainForums = daoContext.MainForums.ToList();
        return mainForums;
    }
}