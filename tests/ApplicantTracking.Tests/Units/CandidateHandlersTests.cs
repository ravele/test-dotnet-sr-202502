using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicantTracking.Application.Commands;
using ApplicantTracking.Application.Handlers;
using ApplicantTracking.Application.Queries;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using Moq;
using Xunit;

namespace ApplicantTracking.Tests.Units;

public class CandidateHandlersTests
{
    private readonly Mock<ICandidateRepository> _mockRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public CandidateHandlersTests()
    {
        _mockRepository = new Mock<ICandidateRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task GetCandidatesHandler_ShouldReturnCandidates()
    {
        var candidates = new List<Candidate> { new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" } };
        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(candidates);
        var handler = new GetCandidatesHandler(_mockRepository.Object);

        var result = await handler.Handle(new GetCandidatesQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetCandidateByIdHandler_ShouldReturnCandidate_WhenFound()
    {
        var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" };
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(candidate);
        var handler = new GetCandidateByIdHandler(_mockRepository.Object);

        var result = await handler.Handle(new GetCandidateByIdQuery(1), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("John", result.Name);
    }

    [Fact]
    public async Task CreateCandidateHandler_ShouldCreateCandidate()
    {
        var command = new CreateCandidateCommand("John", "Doe", DateTime.UtcNow, "john.doe@example.com");
        var handler = new CreateCandidateHandler(_mockRepository.Object, _mockUnitOfWork.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(command.Name, result.Name);
    }

    [Fact]
    public async Task UpdateCandidateHandler_ShouldUpdateCandidate_WhenFound()
    {
        var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" };
        _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(candidate);
        var command = new UpdateCandidateCommand(1, "John", "Smith", DateTime.UtcNow, "john.smith@example.com");
        var handler = new UpdateCandidateHandler(_mockRepository.Object, _mockUnitOfWork.Object);

        await handler.Handle(command, CancellationToken.None);

        Assert.Equal("Smith", candidate.Surname);
    }

    [Fact]
    public async Task DeleteCandidateHandler_ShouldDeleteCandidate_WhenFound()
    {
        var handler = new DeleteCandidateHandler(_mockRepository.Object, _mockUnitOfWork.Object);
        var command = new DeleteCandidateCommand(1);

        await handler.Handle(command, CancellationToken.None);

        _mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }
}
