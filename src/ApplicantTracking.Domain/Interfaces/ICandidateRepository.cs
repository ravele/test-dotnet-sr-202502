using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicantTracking.Domain.Entities;

namespace ApplicantTracking.Domain.Interfaces;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>> GetAllAsync();

    Task<Candidate> GetByIdAsync(int id);

    Task AddAsync(Candidate candidate);

    void Update(Candidate candidate);

    Task DeleteAsync(int id);
}
