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
  
    
    /*
    

  

    public Task<Forum> AddForumAsync(Forum forum)
    {
        throw new NotImplementedException();
    }

    public ICollection<Forum> GetAllForumAsync()
    {
      ICollection<Forum> AllForum =   forumFileContext.GetAllForumAsync();
      return  AllForum;
    }

    */
    public async Task<MainForum> AddMainForumAsync(MainForum mainForum)
    {
       int largestId = forumFileContext.MainForums.Max(t => t.MainForumId);
        int nextId = largestId+1;
        mainForum.MainForumId = nextId;
        Console.WriteLine("Inside Forum serice Impl 35");
        Console.WriteLine(mainForum.CreatedBy + " .." + mainForum.Title + mainForum.MainForumId );
        forumFileContext.MainForums?.Add(mainForum);
        await forumFileContext.SaveChanges();
        return mainForum;
    }

    public MainForum GetMainForumAsync(int id)
    {
        MainForum mainForum = forumFileContext.GetMainForumById(id);
        return mainForum;
    }

    public ICollection<MainForum>? GetAllForums()
    {
        ICollection<MainForum>? mainForums = forumFileContext.MainForums;
        return mainForums;
    }


}