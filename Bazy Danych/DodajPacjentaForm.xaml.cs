using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy DodajPacjentaForm.xaml
    /// </summary>
    public partial class DodajPacjentaForm : Window
    {
        public DodajPacjentaForm()
        {
            InitializeComponent();
        }
        /*private void AddPatientBtn_Click(object sender, RoutedEventArgs e)
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
        }*/
    }
}
