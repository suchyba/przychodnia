using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Pielegniarka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PESEL { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]

        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public Adres adres { get; set; }
        public ICollection<Zabieg> zabiegi { get; set; } =
        new HashSet<Zabieg>();
    }
}
