namespace Entities.Model;

public class Forum
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Username { get; set; }
    public int Id { get; set; }


    public Forum(string title, string description, string username, int id)
    {
        Title = title;
        Description = description;
        Username = username;
        Id = Id;
    }

    public Forum()
    {
    }
}