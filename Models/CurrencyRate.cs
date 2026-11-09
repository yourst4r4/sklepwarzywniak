using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("currency_rates")]
[Index("CurrencyId", "RateDate", Name = "currency_rates_currency_id_rate_date_key", IsUnique = true)]
public partial class CurrencyRate
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("currency_id")]
    public long CurrencyId { get; set; }

    [Column("rate")]
    [Precision(14, 6)]
    public decimal Rate { get; set; }

    [Column("rate_date")]
    public DateOnly RateDate { get; set; }

    [Column("source")]
    [StringLength(50)]
    public string Source { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("CurrencyRates")]
    public virtual Currency Currency { get; set; } = null!;
}
