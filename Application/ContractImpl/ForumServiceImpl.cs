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
    
   

    public async Task<Forum> AddForumAsync(int id,Forum forum)
    {
        Console.WriteLine("Service impl 12");
        await forumDao.AddForumAsync(id,forum);
        return forum;
    }
    
/*
    public ICollection<Forum> GetAllForumAsync()
    {
        ICollection<Forum> AllForums =  forumDao.GetAllForumAsync();
        return AllForums;
    }
    */

    public async Task<MainForum> AddMainForum(MainForum mainForum)
    {
        Console.WriteLine("Inside Forum serice Impl 35");
        Console.WriteLine(mainForum.CreatedBy + " .." + mainForum.Title );
        await forumDao.AddMainForumAsync(mainForum);

        Console.WriteLine("Inside Forum serice Impl 38");
        return mainForum;
    }

    public async Task<MainForum> GetMainForumById(int id)
    {
        MainForum mainForum = forumDao.GetMainForumAsync(id);
        return mainForum;
    }

    public async Task<ICollection<MainForum>?> GetAllForums()
    {
        ICollection<MainForum>? mainForums = forumDao.GetAllForums();
        Console.WriteLine(mainForums.Count);
        return mainForums;
    }

    public void IncrementTotalViews(int id)
    {
        forumDao.IncrementTotalViews(id);
    }
}