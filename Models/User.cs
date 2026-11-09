using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("users")]
[Index("Email", Name = "users_email_key", IsUnique = true)]
[Index("Login", Name = "users_login_key", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("login")]
    [StringLength(100)]
    public string Login { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("phone")]
    [StringLength(30)]
    public string? Phone { get; set; }

    [Column("role")]
    [StringLength(20)]
    public string Role { get; set; } = null!;

    [Column("show_net_prices")]
    public bool ShowNetPrices { get; set; }

    [Column("newsletter_enabled")]
    public bool NewsletterEnabled { get; set; }

    [Column("products_per_page")]
    public int ProductsPerPage { get; set; }

    [Column("preferred_currency_id")]
    public long? PreferredCurrencyId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("User")]
    public virtual Cart? Cart { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ContactMessage> ContactMessages { get; set; } = new List<ContactMessage>();

    [InverseProperty("User")]
    public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; } = new List<CustomerDiscount>();

    [InverseProperty("User")]
    public virtual ICollection<NewsletterLog> NewsletterLogs { get; set; } = new List<NewsletterLog>();

    [InverseProperty("ChangedByNavigation")]
    public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = new List<PasswordResetToken>();

    [ForeignKey("PreferredCurrencyId")]
    [InverseProperty("Users")]
    public virtual Currency? PreferredCurrency { get; set; }

    [InverseProperty("User")]
    public virtual UserPreference? UserPreference { get; set; }
}
