using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bazy_Danych.Model
{
    public class Recepta
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Pacjent pacjent { get; set; }
        [Required]
        public Lekarz lekarz { get; set; }
        public ICollection<LekRecepta> leki { get; set; } =
        new HashSet<LekRecepta>();
    }
}
