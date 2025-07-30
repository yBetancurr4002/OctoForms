using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OctoForms.Data.Entities;

[Table("SurveyStatus")]
[Index("Name", Name = "UQ__SurveySt__737584F6439981BE", IsUnique = true)]
public partial class SurveyStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
