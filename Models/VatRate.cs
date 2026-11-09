using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("vat_rates")]
public partial class VatRate
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("rate")]
    [Precision(5, 2)]
    public decimal Rate { get; set; }

    [Column("is_exempt")]
    public bool IsExempt { get; set; }

    [InverseProperty("VatRate")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
