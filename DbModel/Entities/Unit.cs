using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbModel.Entities
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Img { get; set; }

        public string Description { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        public int SubjectId { get; set; }

        public ICollection<Case> Cases { get; set; } = new List<Case>();
    }
}
