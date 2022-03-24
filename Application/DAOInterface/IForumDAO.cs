using Entities.Model;

namespace Application.DAOInterface;

public interface IForumDAO
{
    //public Task<Forum> AddForumAsync(Forum forum);
    // public  ICollection<Forum> GetAllForumAsync();
   public Task<MainForum> AddMainForumAsync(MainForum mainForum);

    //  ICollection<MainForum> GetALLMainForumHomeForHomepage();
    MainForum GetMainForumAsync(int id);
    
    ICollection<MainForum>? GetAllForums();
}