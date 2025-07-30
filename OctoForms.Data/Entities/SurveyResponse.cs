using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

public partial class SurveyResponse
{
    [Key]
    public int Id { get; set; }

    public int SurveyId { get; set; }

    public int? UserId { get; set; }

    public DateTime SubmittedDate { get; set; }

    public bool IsCompleted { get; set; }

    [StringLength(45)]
    public string? IpAddress { get; set; }

    [InverseProperty("SurveyResponse")]
    public virtual ICollection<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    [ForeignKey("SurveyId")]
    [InverseProperty("SurveyResponses")]
    public virtual Survey Survey { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SurveyResponses")]
    public virtual User? User { get; set; }
}
