using Application.DAOInterface;
using Contracts;
using Entities.Model;

namespace Application.ContractImpl;

public class ForumServiceImpl:IForumService
{
    private IForumDAO forumDao;

    public ForumServiceImpl(IForumDAO forumDao)
    {
        this.forumDao = forumDao;
    }

    public async Task<Forum> AddForumAsync(Forum forum)
    {
        Console.WriteLine("Service impl 12");
        await forumDao.AddForumAsync(forum);
        return forum;
    }

    public ICollection<Forum> GetAllForumAsync()
    {
        ICollection<Forum> AllForums =  forumDao.GetAllForumAsync();
        return AllForums;
    }

   
}