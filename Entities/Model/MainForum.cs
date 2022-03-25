using System.Collections;

namespace Entities.Model;

public class MainForum
{
    //public ICollection<Forum>? AllForum { get; set; }
    public int? NoOfLikes { get; set; }
    public string? CreatedBy { get; set; }

    public string? Title { get; set; }
    public int  MainForumId { get; set; }
    public ICollection<Forum>? AllSubForums{ get; set; }

    public int? lastId { get; set; }

    public MainForum( string createdBy,string title, ICollection<Forum>? forum)
    {
        //AllForum = allForum;
        NoOfLikes = 0;
        CreatedBy = createdBy;
        Title = title;
        AllSubForums = forum;
        lastId = 0;
    }

    public MainForum()
    {
        NoOfLikes = 0;
        lastId = 0;
    }


    
}