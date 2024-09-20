using Microsoft.EntityFrameworkCore;

namespace VolunteerVision.Infra.Persistence;

internal class VolunteerVisionDbContext(
    DbContextOptions<VolunteerVisionDbContext> options
) : DbContext(options)
{

    // Criando DbSet 
    public DbSet<VolunteerProject> VolunteerProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VolunteerVisionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
