using System;

namespace ApplicantTracking.Domain.Entities;

public class Candidate
{
    public int IdCandidate { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime Birthdate { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastUpdatedAt { get; set; }
}
