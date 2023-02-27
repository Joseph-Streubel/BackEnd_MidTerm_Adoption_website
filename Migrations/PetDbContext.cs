using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class PetDbContext : DbContext{
    public DbSet<Pets> Pets { get; set; }
    public PetDbContext(DbContextOptions<PetDbContext> options)
    :  base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pets>(entity => {
            entity.HasKey(e => e.PetId);
            entity.Property(e => e.PetName).IsRequired();
            entity.Property(e => e.ImgUrl).IsRequired();
            entity.Property(e => e.PetDescription).IsRequired();
            entity.Property(e => e.PetAge).IsRequired();
        });
    }
}