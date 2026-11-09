using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("newsletter_logs")]
public partial class NewsletterLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("subject")]
    [StringLength(255)]
    public string Subject { get; set; } = null!;

    [Column("sent_at", TypeName = "timestamp without time zone")]
    public DateTime SentAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("NewsletterLogs")]
    public virtual User User { get; set; } = null!;
}
