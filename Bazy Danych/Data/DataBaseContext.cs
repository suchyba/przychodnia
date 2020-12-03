using Bazy_Danych.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazy_Danych.Data
{
    class DataBaseContext:DbContext
    {
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Lek> Leki { get; set; }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Pacjent> Pacjeci { get; set; }
        public DbSet<Pielegniarka> Pielegniarki { get; set; }
        public DbSet<Recepta> Recepty { get; set; }
        public DbSet<RodzajZabiegu> RodzajeZabiegow { get; set; }
        public DbSet<Skierowanie> Skierowania { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<Zabieg> Zabiegi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Przychodnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
