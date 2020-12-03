using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    class Wizyta
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        [Required]
        public Lekarz lekarz { get; set; }
        [Required]
        public Pacjent pacjent { get; set; }

        public override string ToString()
        {
            return "Imie: " + pacjent.Imie + " Nazwisko: " + pacjent.Nazwisko + "\n Data: " + Data.ToString();
        }
    }
}
