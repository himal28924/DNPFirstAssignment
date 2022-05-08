using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class DAOContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = /Users/prabina/Desktop/Development/FirstAssignmentDNP/EFC/FirstAssignment.db");
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Forum> Forums { get; set; }

    public DbSet<MainForum> MainForums { get; set; }    
    
    
}