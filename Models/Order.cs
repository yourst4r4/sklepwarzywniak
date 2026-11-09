using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("orders")]
[Index("Status", Name = "idx_orders_status")]
[Index("UserId", Name = "idx_orders_user")]
[Index("OrderNumber", Name = "orders_order_number_key", IsUnique = true)]
public partial class Order
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("order_number")]
    [StringLength(50)]
    public string OrderNumber { get; set; } = null!;

    [Column("status")]
    [StringLength(30)]
    public string Status { get; set; } = null!;

    [Column("payment_method_id")]
    public long? PaymentMethodId { get; set; }

    [Column("shipping_method_id")]
    public long? ShippingMethodId { get; set; }

    [Column("shipping_address")]
    public string ShippingAddress { get; set; } = null!;

    [Column("currency_id")]
    public long CurrencyId { get; set; }

    [Column("total_net")]
    [Precision(12, 2)]
    public decimal TotalNet { get; set; }

    [Column("total_gross")]
    [Precision(12, 2)]
    public decimal TotalGross { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CurrencyId")]
    [InverseProperty("Orders")]
    public virtual Currency Currency { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("Orders")]
    public virtual PaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("ShippingMethodId")]
    [InverseProperty("Orders")]
    public virtual ShippingMethod? ShippingMethod { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
