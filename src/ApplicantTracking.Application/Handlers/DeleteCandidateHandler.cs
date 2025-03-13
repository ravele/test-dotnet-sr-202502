using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Commands;
using ApplicantTracking.Domain.Interfaces;
using MediatR;

namespace ApplicantTracking.Application.Handlers;

public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand>
{
    private readonly ICandidateRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCandidateHandler(ICandidateRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.IdCandidate);
        await _unitOfWork.CommitAsync();
    }
}
