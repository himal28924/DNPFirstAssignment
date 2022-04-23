using System.Text.Json;
using Entities.Model;

namespace JsonDataAccess.FileContext;

public class UserFileContext
{
    private string userPath = "users.json";
    private ICollection<User>? users;

    public UserFileContext()
    {
        if (!File.Exists(userPath))
        {
            CreateFile();
        }
        

    }

    private async void CreateFile()
    {
   
            users = new List<User>();
            await SaveChanges();
    }

  
    public ICollection<User> Users
    {
        get
        {
            if (users == null)
            {
                
                LoadData();
            }
      
            return users!;
        }
    }

    public bool IsUsernameAvailable(string username)
    {
        foreach (var user in Users)
        {
            if (user.UserName.Equals(username))
            {
                return false;
            }
        }
        return true;
    }

    private void LoadData()
    {
        string content = File.ReadAllText(userPath);
            users =JsonSerializer.Deserialize<List<User>>(content);
           
    }
    
    public async Task SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string serialize = JsonSerializer.Serialize(Users,options);
         await File.WriteAllTextAsync(userPath,serialize);
        users = null;
    }

}