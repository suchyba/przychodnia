using Bazy_Danych.Data;
using Bazy_Danych.Model;
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
    /// Interaction logic for EeferralForm.xaml
    /// </summary>
    public partial class EeferralForm : Window
    {
        public Wizyta wizyta { get; set; }
        public EeferralForm()
        {
            InitializeComponent();
        }

        public EeferralForm(Wizyta _wizyta)
        {
            InitializeComponent();
            wizyta = _wizyta;
            WczytajDane();
        }

        private void WczytajDane()
        {
            referralNamePatient.Content = wizyta.pacjent.Imie;
            referralSurnamePatient.Content = wizyta.pacjent.Nazwisko;
            referralNameDoctor.Content = wizyta.lekarz.Imie;
            referralSurnameDoctor.Content = wizyta.lekarz.Nazwisko;

        }
        private void AddRefferBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(RefferNameOperation.Text))
            {
                RefferNameOperation.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                RefferNameOperation.BorderBrush = Brushes.Transparent;
            }
            if (RefferDate.Value == null)
            {
                RefferDate.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                RefferDate.BorderBrush = Brushes.Transparent;
            }


            if (String.IsNullOrEmpty(CityAddPetientBox.Text))
            {
                CityAddPetientBox.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                CityAddPetientBox.BorderBrush = Brushes.Transparent;
            }
            if (String.IsNullOrEmpty(StreetAddPetientBox.Text))
            {
                StreetAddPetientBox.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                StreetAddPetientBox.BorderBrush = Brushes.Transparent;
            }
            if (String.IsNullOrEmpty(NumberAddPetientBox.Text))
            {
                NumberAddPetientBox.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                NumberAddPetientBox.BorderBrush = Brushes.Transparent;
            }
            if (String.IsNullOrEmpty(HouseNumberAddPetientBox.Text))
            {
                HouseNumberAddPetientBox.BorderBrush = Brushes.Red;
                return;
            }
            else
            {
                HouseNumberAddPetientBox.BorderBrush = Brushes.Transparent;
            }
            int numer_domu;
            if (!Int32.TryParse(HouseNumberAddPetientBox.Text, out numer_domu))
            {
                HouseNumberAddPetientBox.BorderBrush = Brushes.Red;
                return;
            }
            int numer_mieszkania = -1;
            if (!String.IsNullOrEmpty(FlatNumberAddPetientBox.Text))
            {
                
                if (!Int32.TryParse(FlatNumberAddPetientBox.Text, out numer_mieszkania))
                {
                    FlatNumberAddPetientBox.BorderBrush = Brushes.Red;
                    return;
                }
            }

            else
            {
                FlatNumberAddPetientBox.BorderBrush = Brushes.Transparent;
            }

            Adres newAdres;
            if (numer_mieszkania != -1)
            {
                newAdres = new Adres
                {
                    Miasto = CityAddPetientBox.Text,
                    Ulica = StreetAddPetientBox.Text,
                    Kod_pocztowy = NumberAddPetientBox.Text,
                    Nr_domu = numer_domu,
                    Nr_mieszkania = numer_mieszkania
                };
            }
            else
            {
                newAdres = new Adres
                {
                    Miasto = CityAddPetientBox.Text,
                    Ulica = StreetAddPetientBox.Text,
                    Kod_pocztowy = NumberAddPetientBox.Text,
                    Nr_domu = numer_domu,
                };
            }

            using DataBaseContext dataBaseContext = new DataBaseContext();

            Adres adresDb = dataBaseContext.Adresy.Where(p => p.Miasto == newAdres.Miasto && p.Ulica == newAdres.Ulica && p.Kod_pocztowy == newAdres.Kod_pocztowy && p.Nr_domu == newAdres.Nr_domu && p.Nr_mieszkania == newAdres.Nr_mieszkania).FirstOrDefault();
            Pacjent pacjentDb = dataBaseContext.Pacjeci.Where(p => p.PESEL == wizyta.pacjent.PESEL).FirstOrDefault();
            Lekarz lekarzDb = dataBaseContext.Lekarze.Where(p => p.PESEL == wizyta.lekarz.PESEL).FirstOrDefault();

            if(pacjentDb == null || lekarzDb == null)
            {
                throw new Exception();
            }
            Skierowanie skierowanie;

            if (adresDb == null)
            {
                 skierowanie = new Skierowanie
                {
                    Nazwa_zabiegu = RefferNameOperation.Text,
                    lekarz = lekarzDb,
                    pacjent = pacjentDb,
                    adres = newAdres,
                    Data_wygasniecia = (DateTime)RefferDate.Value,
                };
            }
            else
            {
                 skierowanie = new Skierowanie
                {
                    Nazwa_zabiegu = RefferNameOperation.Text,
                    lekarz = lekarzDb,
                    pacjent = pacjentDb,
                    adres = adresDb,
                    Data_wygasniecia = (DateTime)RefferDate.Value,
                };
            }

            //Pacjent pacjentDb = dataBaseContext.Pacjeci.Where(p=> p.PESEL == wizyta.pacjent.PESEL).FirstOrDefault();

            //Lekarz lekarzDb = dataBaseContext.Lekarze.Where(p => p.PESEL == wizyta.lekarz.PESEL).FirstOrDefault();

            //if (pacjentDb == null || lekarzDb == null)
            //{
            //    throw new Exception();
            //}

            //dataBaseContext.skierowanie.Add(skierowanie);
            dataBaseContext.Skierowania.Add(skierowanie);
            //lekarzDb.skierowania.Add(skierowanie);

            dataBaseContext.SaveChanges();
            MessageBoxResult result = MessageBox.Show("Dodano skierowanie");

        }

        private void AbordRefferBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
