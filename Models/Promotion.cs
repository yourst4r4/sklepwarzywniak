using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("promotions")]
[Index("StartDate", "EndDate", Name = "idx_promotions_dates")]
public partial class Promotion
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("product_id")]
    public long ProductId { get; set; }

    [Column("discount_percent")]
    [Precision(5, 2)]
    public decimal DiscountPercent { get; set; }

    [Column("start_date", TypeName = "timestamp without time zone")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "timestamp without time zone")]
    public DateTime EndDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Promotions")]
    public virtual Product Product { get; set; } = null!;
}
