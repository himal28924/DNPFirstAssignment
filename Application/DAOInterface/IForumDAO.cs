using Entities.Model;

namespace Application.DAOInterface;

public interface IForumDAO
{
    public Task<Forum> AddForumAsync(Forum forum);
    public  Task<ICollection<Forum>> GetAllForumAsync();
}