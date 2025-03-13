using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Queries;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using MediatR;

namespace ApplicantTracking.Application.Handlers;

public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
{
    private readonly ICandidateRepository _repository;

    public GetCandidateByIdHandler(ICandidateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Candidate> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.IdCandidate);
    }
}
