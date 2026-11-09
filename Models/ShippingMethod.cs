using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("shipping_methods")]
public partial class ShippingMethod
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [InverseProperty("ShippingMethod")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
