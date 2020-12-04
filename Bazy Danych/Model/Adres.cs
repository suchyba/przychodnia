using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Adres
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Miasto { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public string Kod_pocztowy { get; set; }
        [Required]
        public int Nr_domu { get; set; }
        public int? Nr_mieszkania { get; set; }

        public override string ToString()
        {
            return "Miasto: " + Miasto + " Ulica: " + Ulica + " Kod pocztowy: " + Kod_pocztowy + " Numer domu: " + Nr_domu +" Numer mieszkania: "+Nr_mieszkania;
        }
    }
}
