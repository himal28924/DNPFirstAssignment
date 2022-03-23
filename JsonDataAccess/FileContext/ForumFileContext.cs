using System.Text.Json;
using Entities.Model;

namespace JsonDataAccess.FileContext;

public class ForumFileContext
{
    private string forumPath = "forum.json";
    private ICollection<Forum>? forums;

    public ForumFileContext()
    {
        if (!File.Exists(forumPath))
        {
            CreateFile();
        }
        

    }

    private async void CreateFile()
    {
   
        forums = new List<Forum>();
        await SaveChanges();
    }

  
    public ICollection<Forum> Forum
    {
        get
        {
            if (forums == null)
            {
                
                LoadData();
            }
            Console.WriteLine("Inside Forum FIle context");
            return forums!;
        }
    }

   

    private void LoadData()
    {
        string content = File.ReadAllText(forumPath);
        forums =JsonSerializer.Deserialize<List<Forum>>(content);
           
    } 
    
    public async Task SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string serialize = JsonSerializer.Serialize(Forum,options);
        await File.WriteAllTextAsync(forumPath,serialize);
        forums = null;
    }

    public  ICollection<Forum> GetAllForumAsync()
    {
         return Forum;
    }
}