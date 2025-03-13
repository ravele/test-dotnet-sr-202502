using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Queries;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using MediatR;

namespace ApplicantTracking.Application.Handlers;

public class GetCandidatesHandler : IRequestHandler<GetCandidatesQuery, IEnumerable<Candidate>>
{
    private readonly ICandidateRepository _repository;

    public GetCandidatesHandler(ICandidateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Candidate>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
