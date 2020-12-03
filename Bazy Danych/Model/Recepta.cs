using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bazy_Danych.Model
{
    class Recepta
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Pacjent pacjent { get; set; }
        [Required]
        public Lekarz lekarz { get; set; }
        public ICollection<Lek> leki { get; set; } =
        new HashSet<Lek>();
    }
}
