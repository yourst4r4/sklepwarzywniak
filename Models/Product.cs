using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("products")]
[Index("CategoryId", Name = "idx_products_category")]
[Index("CreatedAt", Name = "idx_products_created", AllDescending = true)]
[Index("Name", Name = "idx_products_name")]
[Index("IsVisible", Name = "idx_products_visibility")]
[Index("Symbol", Name = "products_symbol_key", IsUnique = true)]
public partial class Product
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("symbol")]
    [StringLength(100)]
    public string? Symbol { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("price_net")]
    [Precision(12, 2)]
    public decimal PriceNet { get; set; }

    [Column("vat_rate_id")]
    public long VatRateId { get; set; }

    [Column("category_id")]
    public long CategoryId { get; set; }

    [Column("manufacturer_id")]
    public long? ManufacturerId { get; set; }

    [Column("expert_email")]
    [StringLength(255)]
    public string? ExpertEmail { get; set; }

    [Column("is_visible")]
    public bool IsVisible { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp without time zone")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ContactMessage> ContactMessages { get; set; } = new List<ContactMessage>();

    [InverseProperty("Product")]
    public virtual Inventory? Inventory { get; set; }

    [ForeignKey("ManufacturerId")]
    [InverseProperty("Products")]
    public virtual Manufacturer? Manufacturer { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    [ForeignKey("VatRateId")]
    [InverseProperty("Products")]
    public virtual VatRate VatRate { get; set; } = null!;
}
