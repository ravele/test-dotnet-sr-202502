using System.Threading.Tasks;
using ApplicantTracking.Domain.Interfaces;
using ApplicantTracking.Infrastructure.Data;

namespace ApplicantTracking.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
