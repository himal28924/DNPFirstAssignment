using Entities.Model;

namespace Application.DAOInterface;

public interface IForumDAO
{
    public Task<Forum> AddForumAsync(int id,Forum forum);
    // public  ICollection<Forum> GetAllForumAsync();
   public Task<MainForum> AddMainForumAsync(MainForum mainForum);

    //  ICollection<MainForum> GetALLMainForumHomeForHomepage();
    Task<List<Forum>> GetSubForumByMainForumId(int id);
    
    Task<ICollection<MainForum>> GetAllForums();
    
}