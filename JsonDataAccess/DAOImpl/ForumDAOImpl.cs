using Application.DAOInterface;
using Entities.Model;
using JsonDataAccess.FileContext;

namespace JsonDataAccess.DAOImpl;

public class ForumDAOImpl:IForumDAO
{
    
    private  ForumFileContext forumFileContext;

    public ForumDAOImpl(ForumFileContext forumFileContext)
    {
        this.forumFileContext = forumFileContext;
    }
  
    
  
    

  

    public async Task<Forum> AddForumAsync(int id,Forum forum)
    {
    
        forumFileContext.AddSubForum(id, forum);
        await forumFileContext.SaveChanges();
        return forum;
    }
    
    
    /*
      public ICollection<Forum> GetAllForumAsync()
      {
        ICollection<Forum> AllForum =   forumFileContext.GetAllForumAsync();
        return  AllForum;
      }
  
      */
    public async Task<MainForum> AddMainForumAsync(MainForum mainForum)
    {
     int largestId = forumFileContext.MainForums.Max(t => t.MainForumId);
     int nextId = largestId + 1;
    
        mainForum.MainForumId = nextId;
        mainForum.AllSubForums = new List<Forum>();
        forumFileContext.MainForums?.Add(mainForum);
        await forumFileContext.SaveChanges();
        return mainForum;
    }

    public async Task<List<Forum>> GetSubForumByMainForumId(int id)
    {
        MainForum mainForum = forumFileContext.MainForums.First((forum => forum.MainForumId.Equals(id)));
        IncrementTotalViews(id);
        return (List<Forum>) mainForum.AllSubForums;
    }

    public  async Task<ICollection<MainForum>> GetAllForums()
    {
        ICollection<MainForum>? mainForums = forumFileContext.MainForums;
        return mainForums;
    }

    private void IncrementTotalViews(int id)
    {
        forumFileContext.MainForums!.First(forum => forum.MainForumId.Equals(id)).NoOfViews += 1;
        forumFileContext?.SaveChanges();
    }
}