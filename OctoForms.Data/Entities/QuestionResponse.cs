using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

public partial class QuestionResponse
{
    [Key]
    public int Id { get; set; }

    public int SurveyResponseId { get; set; }

    public int QuestionId { get; set; }

    public string? TextAnswer { get; set; }

    public string? SelectedOptionIds { get; set; }

    [StringLength(500)]
    public string? FileUploadPath { get; set; }

    [StringLength(255)]
    public string? OriginalFileName { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("QuestionResponses")]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey("SurveyResponseId")]
    [InverseProperty("QuestionResponses")]
    public virtual SurveyResponse SurveyResponse { get; set; } = null!;
}
