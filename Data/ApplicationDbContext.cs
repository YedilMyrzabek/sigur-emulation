using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sigur_emulation.Models;

namespace sigur_emulation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Position> Positions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Personnel> Personnels { get; set; }
    public DbSet<AccessRule> AccessRules { get; set; }
    public DbSet<Card> Cards { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Parent)
            .WithMany()
            .HasForeignKey(d => d.ParentId);
            
        modelBuilder.Entity<Position>()
            .HasIndex(p => p.Id)
            .IsUnique();
        
        modelBuilder.Entity<Department>()
            .HasIndex(o => o.Id)
            .IsUnique();

        modelBuilder.Entity<Area>()
            .HasIndex(st => st.Id)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasIndex(p => p.Id)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasIndex(p => p.TabId)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(p => p.DepartmentId);

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Area)
            .WithMany()
            .HasForeignKey(p => p.AreaId);

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Position)
            .WithMany()
            .HasForeignKey(p => p.PositionId);
        
        modelBuilder.Entity<AccessRule>()
            .HasOne(ar => ar.Employee)
            .WithMany()
            .HasForeignKey(ar => ar.EmployeeId);
        
        modelBuilder.Entity<AccessRule>()
            .HasIndex(ar => new { ar.EmployeeId, ar.AccessRuleId })
            .IsUnique();
        
        modelBuilder.Entity<Card>()
            .HasOne(c => c.Holder)
            .WithMany()
            .HasForeignKey(f => f.CardHolderId);
        
        modelBuilder.Entity<Card>()
            .HasIndex(c => c.Id)
            .IsUnique();

        modelBuilder.Entity<CardHolder>()
            .HasKey(c => c.HolderId);

        modelBuilder.Entity<CardHolder>()
            .HasOne(ch => ch.Personnel)
            .WithMany()
            .HasForeignKey(ch => ch.HolderId);
    }
}