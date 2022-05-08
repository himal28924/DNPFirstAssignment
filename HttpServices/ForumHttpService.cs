using System.Text;
using System.Text.Json;
using Contracts;
using Entities.Model;

namespace HttpServices;

public class ForumHttpService : IForumService
{
    public async Task<Forum> AddForumAsync(int id, Forum forum)
    {
        
        using HttpClient client = new();

        string forumAsJson = JsonSerializer.Serialize(forum);

        StringContent content = new(forumAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7079/Forum/{id}", content);
        string responseContent = await response.Content.ReadAsStringAsync();
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
    
        Forum returned = JsonSerializer.Deserialize<Forum>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return returned;
    }

    public async Task<MainForum> AddMainForum(MainForum mainForum)
    {
        using HttpClient client = new();

        string forumAsJson = JsonSerializer.Serialize(mainForum);

        StringContent content = new(forumAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7079/Forum", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
       
        MainForum returned = JsonSerializer.Deserialize<MainForum>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
    
        return returned;
    }

    public async Task<List<Forum>> GetSubForumByMainForumId(int id)
    {
        using HttpClient client = new ();
                 
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/Forum/{id}");
        
        string content = await response.Content.ReadAsStringAsync();
        
       
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        List<Forum> forums = JsonSerializer.Deserialize<List<Forum>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        
        return forums;
    }

    public async Task<ICollection<MainForum>?> GetAllForums()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/Forum");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
       
        ICollection<MainForum> mainForum = JsonSerializer.Deserialize<ICollection<MainForum>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return mainForum;
    }

    
}