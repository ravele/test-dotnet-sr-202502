using System.Collections.Generic;
using ApplicantTracking.Domain.Entities;
using MediatR;

namespace ApplicantTracking.Application.Queries;

public record GetCandidatesQuery() : IRequest<IEnumerable<Candidate>>;
