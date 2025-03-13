using ApplicantTracking.Domain.Entities;
using MediatR;

namespace ApplicantTracking.Application.Queries;

public record GetCandidateByIdQuery(int IdCandidate) : IRequest<Candidate>;
