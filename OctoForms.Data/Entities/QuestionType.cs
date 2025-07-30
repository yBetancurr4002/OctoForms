using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

[Table("QuestionType")]
[Index("Name", Name = "UQ__Question__737584F6C294BE4E", IsUnique = true)]
public partial class QuestionType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("QuestionType")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
