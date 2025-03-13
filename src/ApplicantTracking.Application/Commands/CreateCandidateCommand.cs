using System;
using ApplicantTracking.Domain.Entities;
using MediatR;

namespace ApplicantTracking.Application.Commands;

public record CreateCandidateCommand(string Name, string Surname, DateTime Birthdate, string Email) : IRequest<Candidate>;
