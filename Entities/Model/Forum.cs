namespace Entities.Model;

public class Forum
{
    public string title { get; set; }
    public string description { get; set; }

    public Forum(string title, string description)
    {
        this.title = title;
        this.description = description;
    }
}