using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("order_status_history")]
public partial class OrderStatusHistory
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("order_id")]
    public long OrderId { get; set; }

    [Column("old_status")]
    [StringLength(30)]
    public string? OldStatus { get; set; }

    [Column("new_status")]
    [StringLength(30)]
    public string NewStatus { get; set; } = null!;

    [Column("changed_at", TypeName = "timestamp without time zone")]
    public DateTime ChangedAt { get; set; }

    [Column("changed_by")]
    public long? ChangedBy { get; set; }

    [ForeignKey("ChangedBy")]
    [InverseProperty("OrderStatusHistories")]
    public virtual User? ChangedByNavigation { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderStatusHistories")]
    public virtual Order Order { get; set; } = null!;
}
