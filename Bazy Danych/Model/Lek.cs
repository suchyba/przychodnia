using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    class Lek
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nazwa_leku { get; set; }
        [Required]
        public string Dawkowanie { get; set; }
        [Required]
        public decimal Cena { get; set; }
        public ICollection<Recepta> recepty { get; set; } =
        new HashSet<Recepta>();
    }
}
