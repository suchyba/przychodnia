﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    class Zabieg
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
    }
}