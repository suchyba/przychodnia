﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    class Skierowanie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nazwa_zabiegu { get; set; }
        [Required]
        public DateTime Data_wygasniecia { get; set; }
        [Required]
        public Pacjent pacjent { get; set; }
        [Required]
        public Lekarz lekarz { get; set; }
        [Required]
        public Adres adres { get; set; }
    }
}
