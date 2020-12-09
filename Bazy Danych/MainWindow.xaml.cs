using Bazy_Danych.Data;
using Bazy_Danych.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bazy_Danych
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NurseForm nurseForm;
        private DoctorForm doctorForm;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            przykladoweDane();
        }

        private void przykladoweDane()
        {
            
                Adres a1 = new Adres
            {
                Miasto = "Białystok",
                Ulica = "Warszawska",
                Kod_pocztowy = "5-105",
                Nr_domu = 10
            };
            Adres a2 = new Adres
            {
                Miasto = "Warszawa",
                Ulica = "Legionowa",
                Kod_pocztowy = "13-102",
                Nr_domu = 12
            };
            Adres a3 = new Adres
            {
                Miasto = "Gdynia",
                Ulica = "Bohaterów",
                Kod_pocztowy = "12-112",
                Nr_domu = 1
            };
            Lekarz lekarz1 = new Lekarz
            {
                PESEL = 11,
                Password = "11",
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Specjalizacja = "Chirureg",
                adres = a1

            };

            Lekarz lekarz2 = new Lekarz
            {
                PESEL = 12,
                Password = "12",
                Imie = "Monika",
                Nazwisko = "Dalman",
                Specjalizacja = "Psycholog",
                adres = a3
            };

            Lekarz lekarz3 = new Lekarz
            {
                PESEL = 13,
                Password = "13",
                Imie = "Wojciech",
                Nazwisko = "Niemyjśki",
                Specjalizacja = "Stomatolog",
                adres = a2
            };

            Pielegniarka pielegniarka1 = new Pielegniarka
            {
                PESEL = 21,
                Password = "21",
                Imie = "Andrzej",
                Nazwisko = "Litwińczuk",
                adres = a1

            };

            Pielegniarka pielegniarka2 = new Pielegniarka
            {
                PESEL = 22,
                Password = "22",
                Imie = "Krystyna",
                Nazwisko = "Drozdowska",
                adres = a3

            };

            Pielegniarka pielegniarka3 = new Pielegniarka
            {
                PESEL = 23,
                Password = "23",
                Imie = "Jan",
                Nazwisko = "Malecki",
                adres = a1

            };

            Pacjent pacjent1 = new Pacjent
            {
                PESEL = 31,
                Imie = "Wiesław",
                Nazwisko = "Wyborny",
                adres = a3

            };

            Pacjent pacjent2 = new Pacjent
            {
                PESEL = 32,
                Imie = "Grzegorz",
                Nazwisko = "Kowal",
                adres = a1

            };

            Pacjent pacjent3 = new Pacjent
            {
                PESEL = 33,
                Imie = "Przemysław",
                Nazwisko = "Jajo",
                adres = a2

            };

            using DataBaseContext dataBaseContext = new DataBaseContext();

            var lekarz11 = dataBaseContext.Lekarze.Where(p => p.PESEL == 11).FirstOrDefault();
            var lekarz12 = dataBaseContext.Lekarze.Where(p => p.PESEL == 12).FirstOrDefault();
            var lekarz13 = dataBaseContext.Lekarze.Where(p => p.PESEL == 13).FirstOrDefault();

            var pacjent11 = dataBaseContext.Pacjeci.Where(p => p.PESEL == 31).FirstOrDefault();
            var pacjent12 = dataBaseContext.Pacjeci.Where(p => p.PESEL == 32).FirstOrDefault();
            var pacjent13 = dataBaseContext.Pacjeci.Where(p => p.PESEL == 33).FirstOrDefault();

            Wizyta wizyta1 = new Wizyta
            {
                Data = new DateTime(),
                lekarz = lekarz11,
                pacjent = pacjent11
            };
            Wizyta wizyta2 = new Wizyta
            {
                Data = new DateTime(),
                lekarz = lekarz12,
                pacjent = pacjent13,
                Opis = "Opis wizyty"
            };
            Wizyta wizyta3 = new Wizyta
            {
                Data = new DateTime(),
                lekarz = lekarz12,
                pacjent = pacjent12,
                Opis = "Opis wizyty"
            };
            Wizyta wizyta4 = new Wizyta
            {
                Data = new DateTime(),
                lekarz = lekarz11,
                pacjent = pacjent13,
                Opis = "Opis wizyty"
            };
            Lek lek1 = new Lek
            {
                Nazwa_leku = "Antybioty",
                Cena = 12.5M,
                Dawkowanie = "2 razy dziennie",

            };
            Lek lek2 = new Lek
            {
                Nazwa_leku = "Witamina C",
                Cena = 5.5M,
                Dawkowanie = "3 razy dziennie",

            };
            Lek lek3 = new Lek
            {
                Nazwa_leku = "Paracetamon",
                Cena = 15M,
                Dawkowanie = "1 razy dziennie",

            };
            if (!dataBaseContext.Lekarze.Any())
            {
                dataBaseContext.Add(lekarz1);
                dataBaseContext.Add(lekarz2);
                dataBaseContext.Add(lekarz3);
            }
            if(!dataBaseContext.Pielegniarki.Any())
            {
                dataBaseContext.Add(pielegniarka1);
                dataBaseContext.Add(pielegniarka2);
                dataBaseContext.Add(pielegniarka3);
            }
            if(!dataBaseContext.Pacjeci.Any())
            {
                dataBaseContext.Add(pacjent1);
                dataBaseContext.Add(pacjent2);
                dataBaseContext.Add(pacjent3);
            }
            if(!dataBaseContext.Wizyty.Any())
            {
                dataBaseContext.Add(wizyta1);
                dataBaseContext.Add(wizyta2);
                dataBaseContext.Add(wizyta3);
                dataBaseContext.Add(wizyta4);
            }
            if(!dataBaseContext.Leki.Any())
            {
                dataBaseContext.Add(lek1);
                dataBaseContext.Add(lek2);
                dataBaseContext.Add(lek3);
            }
            dataBaseContext.SaveChanges();
        }
        private void ZalogujBtn_Click(object sender, RoutedEventArgs e)
        {
            Wynik.Visibility = Visibility.Collapsed;
            userLogin.ClearValue(TextBox.BorderBrushProperty);
            userPassword.ClearValue(TextBox.BorderBrushProperty);

            int login;

            if (!Int32.TryParse(userLogin.Text, out login))
            {
                userLogin.BorderBrush = Brushes.Red;

                return;
            }
            string password = userPassword.Password.ToString();

            using DataBaseContext dataBaseContext = new DataBaseContext();

            Lekarz user = dataBaseContext.Lekarze.Where(p => p.PESEL == login).FirstOrDefault();


            if (user != null)
            {

                if (user.Password == password)
                {
                    this.Visibility = Visibility.Collapsed;
                    doctorForm = new DoctorForm(user.PESEL);
                    doctorForm.ShowDialog();
                    this.Visibility = Visibility.Visible;
                    userLogin.Text = "";
                    userPassword.Password = "";
                    return;
                }

                userPassword.BorderBrush = Brushes.Red;
                return;
            }

            Pielegniarka user2 = dataBaseContext.Pielegniarki.Where(p => p.PESEL == login).FirstOrDefault();

            if (user2 != null)
            {

                if (user2.Password == password)
                {
                    
                    this.Visibility = Visibility.Collapsed;
                    nurseForm = new NurseForm(user2);
                    nurseForm.ShowDialog();
                    this.Visibility = Visibility.Visible;
                        userLogin.Text = "";
                        userPassword.Password = "";
                    return;
                }
                userPassword.BorderBrush = Brushes.Red;
                return;


            }
            Wynik.Content = "Podany użytkownik nie istnieje!";
            Wynik.Visibility = Visibility.Visible;
            return;

        }
    }
}
