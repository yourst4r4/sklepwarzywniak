using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("cart_items")]
[Index("CartId", "ProductId", Name = "cart_items_cart_id_product_id_key", IsUnique = true)]
[Index("CartId", Name = "idx_cart_items_cart")]
public partial class CartItem
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("cart_id")]
    public long CartId { get; set; }

    [Column("product_id")]
    public long ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("CartItems")]
    public virtual Cart Cart { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("CartItems")]
    public virtual Product Product { get; set; } = null!;
}
