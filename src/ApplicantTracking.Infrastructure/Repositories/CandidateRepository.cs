using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using ApplicantTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicantTracking.Infrastructure.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly ApplicationDbContext _context;

    public CandidateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Candidate>> GetAllAsync()
    {
        return await _context.Candidates.ToListAsync();
    }

    public async Task<Candidate> GetByIdAsync(int id)
    {
        return await _context.Candidates.FindAsync(id);
    }

    public async Task AddAsync(Candidate candidate)
    {
        await _context.Candidates.AddAsync(candidate);
    }

    public void Update(Candidate candidate)
    {
        _context.Candidates.Update(candidate);
    }

    public async Task DeleteAsync(int id)
    {
        var candidate = await _context.Candidates.FindAsync(id);
        if (candidate != null)
        {
            _context.Candidates.Remove(candidate);
        }
    }
}
