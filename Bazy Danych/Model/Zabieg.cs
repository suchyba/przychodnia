using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Zabieg
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public Lekarz lekarz { get; set; }
        [Required]
        public Pielegniarka pielegniarka { get; set; }
        [Required]
        public Pacjent pacjent { get; set; }
        [Required]
        public RodzajZabiegu rodzajZabiegu { get; set; }
        public override string ToString()
        {
            return pacjent.Imie + " " + pacjent.Nazwisko + " " + Data.ToString("dd.M.yyyy") + "\n" + rodzajZabiegu;
        }
    }
}
