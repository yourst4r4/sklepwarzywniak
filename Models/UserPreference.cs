using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("user_preferences")]
public partial class UserPreference
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("theme_id")]
    public long? ThemeId { get; set; }

    [Column("language_id")]
    public long? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("UserPreferences")]
    public virtual Language? Language { get; set; }

    [ForeignKey("ThemeId")]
    [InverseProperty("UserPreferences")]
    public virtual Theme? Theme { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserPreference")]
    public virtual User User { get; set; } = null!;
}
