using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

public partial class QuestionOption
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    [StringLength(200)]
    public string OptionText { get; set; } = null!;

    public int OrderIndex { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("QuestionOptions")]
    public virtual Question Question { get; set; } = null!;
}
