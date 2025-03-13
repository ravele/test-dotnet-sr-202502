using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Commands;
using ApplicantTracking.Domain.Interfaces;
using MediatR;

namespace ApplicantTracking.Application.Handlers;

public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand>
{
    private readonly ICandidateRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCandidateHandler(ICandidateRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _repository.GetByIdAsync(request.IdCandidate);
        if (candidate == null) return;

        candidate.Name = request.Name;
        candidate.Surname = request.Surname;
        candidate.Birthdate = request.Birthdate;
        candidate.Email = request.Email;
        candidate.LastUpdatedAt = DateTime.UtcNow;

        _repository.Update(candidate);
        await _unitOfWork.CommitAsync();
    }
}
