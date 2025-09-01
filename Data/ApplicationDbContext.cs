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
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<StructuralUnit> StructuralUnits { get; set; }
    public DbSet<Personnel> Personnels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dictionaryConverter = new ValueConverter<Dictionary<string, string>, string>(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null)!);

        modelBuilder.Entity<Position>()
            .Property(p => p.Name)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);

        modelBuilder.Entity<Position>()
            .Property(p => p.ShortName)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);
        
        
        modelBuilder.Entity<Position>()
            .HasIndex(p => p.ExternalId)
            .IsUnique();

        modelBuilder.Entity<Organization>()
            .Property(p => p.Name)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);

        modelBuilder.Entity<Organization>()
            .Property(p => p.ShortName)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);

        modelBuilder.Entity<Organization>()
            .HasOne(p => p.Parent)
            .WithMany(o => o.Children)
            .HasForeignKey(pi => pi.ParentId);
        
        modelBuilder.Entity<Organization>()
            .HasIndex(o => o.ExternalId)
            .IsUnique();

        modelBuilder.Entity<StructuralUnit>()
            .Property(p => p.Name)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);

        modelBuilder.Entity<StructuralUnit>()
            .Property(p => p.ShortName)
            .HasColumnType("jsonb")
            .HasConversion(dictionaryConverter);

        modelBuilder.Entity<StructuralUnit>()
            .HasOne(p => p.Organization)
            .WithMany(st => st.StructuralUnits)
            .HasForeignKey(o => o.OrganizationId);

        modelBuilder.Entity<StructuralUnit>()
            .HasOne(p => p.Parent)
            .WithMany(st => st.Children)
            .HasForeignKey(stk => stk.ParentId);

        modelBuilder.Entity<StructuralUnit>()
            .HasIndex(st => st.ExternalId)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasIndex(p => p.ExternalId)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasIndex(p => p.TabulatedNumber)
            .IsUnique();

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Organization)
            .WithMany()
            .HasForeignKey(p => p.OrganizationId);

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.StructuralUnit)
            .WithMany()
            .HasForeignKey(p => p.StructuralUnitId);

        modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Position)
            .WithMany()
            .HasForeignKey(p => p.PositionId);
    }
}