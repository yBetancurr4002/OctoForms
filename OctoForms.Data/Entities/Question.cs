using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

public partial class Question
{
    [Key]
    public int Id { get; set; }

    public int SurveyId { get; set; }

    [StringLength(500)]
    public string QuestionText { get; set; } = null!;

    public int QuestionTypeId { get; set; }

    public bool IsRequired { get; set; }

    public int OrderIndex { get; set; }

    public int? MaxCharacters { get; set; }

    public int? MinSelections { get; set; }

    public int? MaxSelections { get; set; }

    [InverseProperty("Question")]
    public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();

    [InverseProperty("Question")]
    public virtual ICollection<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    [ForeignKey("QuestionTypeId")]
    [InverseProperty("Questions")]
    public virtual QuestionType QuestionType { get; set; } = null!;

    [ForeignKey("SurveyId")]
    [InverseProperty("Questions")]
    public virtual Survey Survey { get; set; } = null!;
}
