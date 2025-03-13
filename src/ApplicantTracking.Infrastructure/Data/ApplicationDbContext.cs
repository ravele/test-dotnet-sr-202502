using ApplicantTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicantTracking.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Candidate> Candidates { get; set; }
}
