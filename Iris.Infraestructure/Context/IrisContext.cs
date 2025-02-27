using Iris.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iris.Infraestructure.Context;

public class IrisContext(DbContextOptions<IrisContext> options):DbContext(options)
{
    public virtual DbSet<ToDo> ToDoes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null) return;

        modelBuilder.Entity<ToDo>
            (
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }
            );

        base.OnModelCreating(modelBuilder);
    }
}
