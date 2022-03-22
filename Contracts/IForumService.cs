using Entities.Model;

namespace Contracts;

public interface IForumService
{
    public Task<Forum> AddForumAsync(Forum forum);
}