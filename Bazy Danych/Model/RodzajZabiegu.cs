﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class RodzajZabiegu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
