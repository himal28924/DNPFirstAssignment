using System.Text.Json;
using Entities.Model;

namespace JsonDataAccess.FileContext;

public class ForumFileContext
{
   // private string forumPath = "forum.json";
    // private ICollection<Forum>? forums;
    private ICollection<MainForum>? mainForums;
    private string mainForumPath = "mainForum.json";

    /*
     
     // FOR JUST SUB  FORUMSS 
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
    
    public  ICollection<Forum> GetAllForumAsync()
    {
         return Forum;
    }
    */

    public ForumFileContext()
    {
        if (!File.Exists(mainForumPath))
        {
            CreateFile();
        }
    }

   
    private async void CreateFile()
    {
   
        mainForums = new List<MainForum>();
        await SaveChanges();
    }



    public ICollection<MainForum?> MainForums {  
        get
    {
        if (mainForums == null)
        {
                
            LoadData();
        }
      
        return mainForums!;
    } 
    }

    public MainForum GetMainForumById(int id)
    {
      MainForum mainForum =   mainForums.First((forum => forum.MainForumId.Equals(id)));
      return mainForum;

    }

    private void LoadData()
    {
        string content = File.ReadAllText(mainForumPath);
        mainForums =JsonSerializer.Deserialize<List<MainForum>>(content);
           
    } 
    
    public async Task SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string serialize = JsonSerializer.Serialize(MainForums,options);
        await File.WriteAllTextAsync(mainForumPath,serialize);
        mainForums = null;
    }
    
}