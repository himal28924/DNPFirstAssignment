namespace Entities.Model;

public class Forum
{
    public string title { get; set; }
    public string description { get; set; }
    public string username { get; set; }
    

    public Forum(string title, string description, string username)
    {
        this.title = title;
        this.description = description;
        this.username = username;
    }
}