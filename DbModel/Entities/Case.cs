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

        [Required]
        public string ImgUrl { get; set; }

        public string Description { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        public int UnitId { get; set; }

        public ICollection<CaseImg> CaseImgs { get; set; } = new List<CaseImg>();
    }
}
