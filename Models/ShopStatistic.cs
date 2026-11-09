using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("shop_statistics")]
[Index("VisitDate", Name = "shop_statistics_visit_date_key", IsUnique = true)]
public partial class ShopStatistic
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("visit_date")]
    public DateOnly VisitDate { get; set; }

    [Column("visits")]
    public long Visits { get; set; }
}
