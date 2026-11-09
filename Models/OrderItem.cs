using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("order_items")]
[Index("ProductId", Name = "idx_order_items_product")]
public partial class OrderItem
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("order_id")]
    public long OrderId { get; set; }

    [Column("product_id")]
    public long? ProductId { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    public string ProductName { get; set; } = null!;

    [Column("product_symbol")]
    [StringLength(100)]
    public string? ProductSymbol { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("unit_price_net")]
    [Precision(12, 2)]
    public decimal UnitPriceNet { get; set; }

    [Column("unit_price_gross")]
    [Precision(12, 2)]
    public decimal UnitPriceGross { get; set; }

    [Column("vat_rate")]
    [Precision(5, 2)]
    public decimal VatRate { get; set; }

    [Column("vat_exempt")]
    public bool VatExempt { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product? Product { get; set; }
}
