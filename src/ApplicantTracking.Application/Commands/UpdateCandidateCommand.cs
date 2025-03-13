using System;
using MediatR;

namespace ApplicantTracking.Application.Commands;

public record UpdateCandidateCommand(int IdCandidate, string Name, string Surname, DateTime Birthdate, string Email) : IRequest;
