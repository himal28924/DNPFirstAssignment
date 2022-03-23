using Application.DAOInterface;
using Entities.Model;
using JsonDataAccess.FileContext;

namespace JsonDataAccess.DAOImpl;

public class ForumDAOImpl:IForumDAO
{
    private ForumFileContext forumFileContext;

    public ForumDAOImpl(ForumFileContext forumFileContext)
    {
        this.forumFileContext = forumFileContext;
    }

    public async Task<Forum> AddForumAsync(Forum forum)
    {
        forumFileContext.Forum.Add(forum);
      
        await forumFileContext.SaveChanges();
        return forum;
    }

    public ICollection<Forum> GetAllForumAsync()
    {
      ICollection<Forum> AllForum =   forumFileContext.GetAllForumAsync();
      return  AllForum;
    }
}