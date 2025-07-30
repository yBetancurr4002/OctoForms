using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

[Index("Username", Name = "UQ__Users__536C85E4B65F6D8C", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534BD318A9B", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(512)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(200)]
    public string? FullName { get; set; }

    [StringLength(50)]
    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();

    [InverseProperty("CreatedBy")]
    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
