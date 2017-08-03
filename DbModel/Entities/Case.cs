using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbModel.Entities
{
  public class Case
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Subname { get; set; }

    public string Description { get; set; }

    public string BeforeImgUrl { get; set; }

    [Required]
    public string AfterImgUrl { get; set; }

    [ForeignKey("SubcategoryId")]
    public Subcategory Subcategory { get; set; }

    public int SubcategoryId { get; set; }

    public int CategoryId { get; set; }
  }
}
