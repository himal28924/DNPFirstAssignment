using Entities.Model;

namespace Contracts;

public interface IForumService
{
    public Task<Forum> AddForumAsync(Forum forum);

    public Task<ICollection<Forum>> GetAllForumAsync();
}