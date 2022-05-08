using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model;

public class MainForum
{
    //public ICollection<Forum>? AllForum { get; set; }
    public int? NoOfViews { get; set; }
    public string? CreatedBy { get; set; }

    public string? Title { get; set; }
    [Key]
    public int  MainForumId { get; set; }
    public ICollection<Forum>? AllSubForums{ get; set; }

    public int lastId { get; set; }

    public MainForum( string createdBy,string title, ICollection<Forum>? forum)
    {
        //AllForum = allForum;
        NoOfViews = 0;
        CreatedBy = createdBy;
        Title = title;
        AllSubForums = forum;
        lastId = 0;
    }

    public MainForum()
    {
        NoOfViews = 0;
        lastId = 0;
    }


    
}