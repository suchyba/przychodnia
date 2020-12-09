using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Lekarz
    {
        [Key]
        public  long PESEL { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Specjalizacja { get; set; }
        [Required]
        public Adres adres { get; set; }
        public ICollection<Wizyta> wizyty { get; set; } = new HashSet<Wizyta>();
        
        public ICollection<Skierowanie> skierowania { get; set; }=
        new HashSet<Skierowanie>();
        public ICollection<Zabieg> zabiegi { get; set; } =
        new HashSet<Zabieg>();
        public ICollection<Recepta> recepty { get; set; } =
        new HashSet<Recepta>();

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
