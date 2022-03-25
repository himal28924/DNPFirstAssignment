using Entities.Model;

namespace Contracts;

public interface IForumService
{
   public Task<Forum> AddForumAsync(int id,Forum forum);

    //public ICollection<Forum> GetAllForumAsync();

    public Task<MainForum> AddMainForum(MainForum mainForum);
    Task<MainForum> GetMainForumById(int id);

 
    Task<ICollection<MainForum>?> GetAllForums();
}