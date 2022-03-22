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
    {Console.WriteLine("Time to save 17 dao impl");
        forumFileContext.Forum.Add(forum);
        Console.WriteLine("i am back to save 19 dao");
        await forumFileContext.SaveChanges();
        return forum;
    }
}