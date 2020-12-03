using Bazy_Danych.Data;
using Bazy_Danych.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bazy_Danych
{
    /// <summary>
    /// Interaction logic for NurseForm.xaml
    /// </summary>
    public partial class NurseForm : Window
    {
        public NurseForm()
        {
            InitializeComponent();
        }

        private void WizytaBtn_Click(object sender, RoutedEventArgs e)
        {
            long PESELPacjeta;
            long PESELDoktora;
            DateTime dataWizyty;

            if (!long.TryParse(PESELTextBox.Text, out PESELPacjeta))
            {
                wizytaLabel.Content = "PESEL pacjeta jest nie prawidłowy";
                return;
            }

            if (!long.TryParse(DoctorPESELTextBox.Text, out PESELDoktora))
            {
                wizytaLabel.Content = "PESEL doktora jest nie prawidłowy";
                return;

            }
            if (DateTextBox.Value == null)
            {
                wizytaLabel.Content = "Nie wybrano daty";
                return;
            }
            dataWizyty = (DateTime)DateTextBox.Value;

            string opisWizyty = opisTextBox.Text;

            using DataBaseContext dataBaseContext = new DataBaseContext();

            var lekarz = dataBaseContext.Lekarze.Where(p => p.PESEL == PESELDoktora);
            var pacjent = dataBaseContext.Pacjeci.Where(p => p.PESEL == PESELPacjeta);

            //Wizyta wizyta = new Wizyta
            //{
            //    Data = new DateTime(DateTextBox.ToString())
            //}
            if (lekarz.Count() > 1 || pacjent.Count() > 1)
            {
                return;
            }
            if (lekarz.Count() == 1 && pacjent.Count() == 1)
            {
                Wizyta wizyta = new Wizyta
                {
                    Data = dataWizyty,
                    Opis = opisWizyty,
                    lekarz = lekarz.First(),
                    pacjent = pacjent.First()
                };
                lekarz.First().wizyty.Add(wizyta);
                pacjent.First().wizyty.Add(wizyta);
                wizytaLabel.Content = "Dodano wizyte";
            }
            dataBaseContext.SaveChanges();
        }

        private void AddPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            long PESELPacjeta;
            string imie;
            string nazwisko;
            string miasto;
            string ulica;
            string kodPocztowy;
            int nrDomu;
            int numerMieszkania = -1;

            if (!long.TryParse(PESELAddPatientBox.Text, out PESELPacjeta))
            {
                wizytaLabel.Content = "PESEL pacjeta jest nie prawidłowy";
                return;
            }
            imie = NameAddPatientBox.Text;
            nazwisko = SurnameAddPatientBox.Text;
            miasto = CityAddPetientBox.Text;
            ulica = SurnameAddPatientBox.Text;
            kodPocztowy = NumberAddPetientBox.Text;
            if (!int.TryParse(HouseNumberAddPetientBox.Text, out nrDomu))
            {
                wizytaLabel.Content = "Nie poprawny nr domu";
                return;
            }
            if (!String.IsNullOrEmpty(FlatNumberAddPetientBox.Text))
            {
                if (!int.TryParse(FlatNumberAddPetientBox.Text, out numerMieszkania))
                {
                    wizytaLabel.Content = "Nie poprawny nr mieszkania";
                    return;
                }
            }



            using DataBaseContext dataBaseContext = new DataBaseContext();

            Adres adres1;
            if (numerMieszkania < 0)
            {
                adres1 = new Adres
                {
                    Miasto = miasto,
                    Ulica = ulica,
                    Kod_pocztowy = kodPocztowy,
                    Nr_domu = nrDomu
                };
            }
            else
            {
                adres1 = new Adres
                {
                    Miasto = miasto,
                    Ulica = ulica,
                    Kod_pocztowy = kodPocztowy,
                    Nr_domu = nrDomu,
                    Nr_mieszkania = numerMieszkania
                };
            }
            Pacjent pacjent = new Pacjent
            {
                PESEL = PESELPacjeta,
                Imie = imie,
                Nazwisko = nazwisko,
                adres = adres1
            };
            wizytaLabel.Content = "Dodano pacjeta";
            dataBaseContext.Add(pacjent);
            dataBaseContext.SaveChanges();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            long PESELPacjeta;

            using DataBaseContext dataBaseContext = new DataBaseContext();
            IQueryable<Pacjent> Wynik;
            if (!String.IsNullOrEmpty(PESELFindPatient.Text) && long.TryParse(PESELFindPatient.Text, out PESELPacjeta))
            {
                Wynik = dataBaseContext.Pacjeci.Include("adres").Where(p => p.PESEL == PESELPacjeta).OrderBy(p => p.PESEL);
                findPatientListBox.ItemsSource = Wynik.ToList();
                findPatientListBox.UpdateLayout();
            }
            else if (!String.IsNullOrEmpty(nameFindPatient.Text) && !String.IsNullOrEmpty(surnameFindPatient.Text))
            {
                Wynik = dataBaseContext.Pacjeci.Include("adres").Where(p => p.Imie == nameFindPatient.Text && p.Nazwisko == surnameFindPatient.Text).OrderBy(p => p.PESEL);
                findPatientListBox.ItemsSource = Wynik.ToList();
                findPatientListBox.UpdateLayout();
            }
            else if (!String.IsNullOrEmpty(nameFindPatient.Text))
            {
                Wynik = dataBaseContext.Pacjeci.Include("adres").Where(p => p.Imie == nameFindPatient.Text).OrderBy(p => p.PESEL);
                findPatientListBox.ItemsSource = Wynik.ToList();
                findPatientListBox.UpdateLayout();
            }
            else if (!String.IsNullOrEmpty(surnameFindPatient.Text))
            {
                Wynik = dataBaseContext.Pacjeci.Include("adres").Where(p => p.Nazwisko == surnameFindPatient.Text).OrderBy(p => p.PESEL);
                findPatientListBox.ItemsSource = Wynik.ToList();
                findPatientListBox.UpdateLayout();
            }
        }
    }
}
