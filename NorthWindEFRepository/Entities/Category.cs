﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NorthWindEFRepository.Entities
{
    public class Category
    {
        [Key]
        [Column("CategoryID")]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [Column("CategoryName")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

    }
}
