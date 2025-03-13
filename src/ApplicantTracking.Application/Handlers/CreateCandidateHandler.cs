using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Commands;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using MediatR;

namespace ApplicantTracking.Application.Handlers;

public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, Candidate>
{
    private readonly ICandidateRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCandidateHandler(ICandidateRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Candidate> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = new Candidate
        {
            Name = request.Name,
            Surname = request.Surname,
            Birthdate = request.Birthdate,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(candidate);
        await _unitOfWork.CommitAsync();

        return candidate;
    }
}
