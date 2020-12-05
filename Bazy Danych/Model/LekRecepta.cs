using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class LekRecepta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Recepta")]
        public Recepta recepta { get; set; }

        [Required]
        [ForeignKey("Lek")]
        public Lek lek { get; set; }
    }
}
