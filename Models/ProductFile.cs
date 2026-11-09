using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Warzywniak.Models;

[Table("product_files")]
[Index("ProductId", Name = "idx_product_files_product")]
public partial class ProductFile
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("product_id")]
    public long ProductId { get; set; }

    [Column("file_name")]
    [StringLength(255)]
    public string FileName { get; set; } = null!;

    [Column("file_path")]
    public string FilePath { get; set; } = null!;

    [Column("file_description")]
    public string? FileDescription { get; set; }

    [Column("uploaded_at", TypeName = "timestamp without time zone")]
    public DateTime UploadedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductFiles")]
    public virtual Product Product { get; set; } = null!;
}
