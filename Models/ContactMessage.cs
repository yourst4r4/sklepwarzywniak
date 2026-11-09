using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("contact_messages")]
public partial class ContactMessage
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [Column("product_id")]
    public long? ProductId { get; set; }

    [Column("sender_email")]
    [StringLength(255)]
    public string SenderEmail { get; set; } = null!;

    [Column("subject")]
    [StringLength(255)]
    public string? Subject { get; set; }

    [Column("message")]
    public string Message { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("is_read")]
    public bool IsRead { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ContactMessages")]
    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ContactMessages")]
    public virtual User? User { get; set; }
}
