using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Lek
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nazwa_leku { get; set; }
        [Required]
        public string Dawkowanie { get; set; }
        [Required]
        public decimal Cena { get; set; }
        public ICollection<LekRecepta> recepty { get; set; } =
        new HashSet<LekRecepta>();

        public override string ToString()
        {
            return "Nazwa leku: "+Nazwa_leku +" Dawkowanie: "+Dawkowanie+ " Cena: "+Cena;
        }
    }
}
