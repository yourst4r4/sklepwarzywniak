using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("currencies")]
[Index("Code", Name = "currencies_code_key", IsUnique = true)]
public partial class Currency
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("code")]
    [StringLength(3)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("exchange_rate")]
    [Precision(14, 6)]
    public decimal ExchangeRate { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Currency")]
    public virtual ICollection<CurrencyRate> CurrencyRates { get; set; } = new List<CurrencyRate>();

    [InverseProperty("Currency")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("PreferredCurrency")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
