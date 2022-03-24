using System.Collections;

namespace Entities.Model;

public class MainForum
{
    //public ICollection<Forum>? AllForum { get; set; }
    public int? NoOfLikes { get; set; }
    public string? CreatedBy { get; set; }

    public string? Title { get; set; }
    public int  MainForumId { get; set; }

    public MainForum( int noOfLikes, string createdBy,string title)
    {
        //AllForum = allForum;
        NoOfLikes = noOfLikes;
        CreatedBy = createdBy;
        Title = title;
    }

    public MainForum()
    {
    }


    
}