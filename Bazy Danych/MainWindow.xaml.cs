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
                    nurseForm = new NurseForm(pielegniarka);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();
            Adres a1 = new Adres
            {
                Miasto = "Pitulic",
                Ulica = "5",
                Kod_pocztowy = "5-1",
                Nr_domu = 1
            };
            Lekarz lekarz1 = new Lekarz
            {
                PESEL = 11,
                Password = "11",
                Imie = "Jan",
                Nazwisko = "Boi",
                Specjalizacja = "Chirureg",
                adres = a1

            };

            Lekarz lekarz2 = new Lekarz
            {
                PESEL = 12,
                Password = "12",
                Imie = "Shrek",
                Nazwisko = "isLove",
                Specjalizacja = "Psycholog",
                adres = a1
            };

            Lekarz lekarz3 = new Lekarz
            {
                PESEL = 13,
                Password = "13",
                Imie = "Gandalf",
                Nazwisko = "Szary",
                Specjalizacja = "EpicReviving",
                adres = a1
            };

            Pielegniarka pielegniarka1 = new Pielegniarka
            {
                PESEL = 21,
                Password = "21",
                Imie = "Yo",
                Nazwisko = "Mama",
                adres = a1

            };

            Pielegniarka pielegniarka2 = new Pielegniarka
            {
                PESEL = 22,
                Password = "22",
                Imie = "Big",
                Nazwisko = "Smoke",
                adres = a1

            };

            Pielegniarka pielegniarka3 = new Pielegniarka
            {
                PESEL = 23,
                Password = "23",
                Imie = "C",
                Nazwisko = "J",
                adres = a1

            };

            Pacjent pacjent1 = new Pacjent
            {
                PESEL = 31,
                Imie = "Bez",
                Nazwisko = "Imienny",
                adres = a1

            };

            Pacjent pacjent2 = new Pacjent
            {
                PESEL = 32,
                Imie = "Ehh",
                Nazwisko = "Nudy",
                adres = a1

            };

            Pacjent pacjent3 = new Pacjent
            {
                PESEL = 33,
                Imie = "Bajo",
                Nazwisko = "Jajo",
                adres = a1

            };
            dataBaseContext.Add(lekarz1);
            dataBaseContext.Add(lekarz2);
            dataBaseContext.Add(lekarz3);

            dataBaseContext.Add(pielegniarka1);
            dataBaseContext.Add(pielegniarka2);
            dataBaseContext.Add(pielegniarka3);

            dataBaseContext.Add(pacjent1);
            dataBaseContext.Add(pacjent2);
            dataBaseContext.Add(pacjent3);
            dataBaseContext.SaveChanges();
        }
    }
}
