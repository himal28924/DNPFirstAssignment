namespace Entities.Model;

public class User
{
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public string? Name { get; set; }    


    public User(string name,string userName, string password)
    {
        UserName = userName;
        Password = password;
        Name = name;
    }

    public User()
    {
       
    }
}