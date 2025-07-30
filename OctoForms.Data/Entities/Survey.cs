using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

public partial class Survey
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Instructions { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int StatusId { get; set; }

    public bool IsAnonymous { get; set; }

    public bool AllowMultipleSubmissions { get; set; }

    public bool AllowResponseEditing { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [ForeignKey("CreatedById")]
    [InverseProperty("Surveys")]
    public virtual User CreatedBy { get; set; } = null!;

    [InverseProperty("Survey")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [ForeignKey("StatusId")]
    [InverseProperty("Surveys")]
    public virtual SurveyStatus Status { get; set; } = null!;

    [InverseProperty("Survey")]
    public virtual ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}
