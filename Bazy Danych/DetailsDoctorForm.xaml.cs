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
    /// Interaction logic for DetailsDoctorForm.xaml
    /// </summary>
    public partial class DetailsDoctorForm : Window
    {
        public long PESELPacjent { get; set; }
        public Pacjent pacjent;
        public Wizyta wizyta1;
        public DetailsDoctorForm()
        {
            InitializeComponent();
        }
        public DetailsDoctorForm(Wizyta wizyta,Pacjent p1)
        {
            InitializeComponent();
            pacjent = p1;
            wizyta1 = wizyta;
            wczytajDane();
        }
        private void wczytajDane()
        {
            peselSzczegolyLabel.Content = pacjent.PESEL;
            imieSzczegolyLabel.Content = pacjent.Imie;
            nazwiskoSzczegolyLabel.Content = pacjent.Nazwisko;
            DataSzczegolyLabel.Content = wizyta1.Data;
            opisWizytyTextBox.Text = wizyta1.Opis;
        }

        private void ZakonczWizyteBtn_Click(object sender, RoutedEventArgs e)
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            Wizyta wizytaDb = dataBaseContext.Wizyty.Where(p => p.ID == wizyta1.ID).FirstOrDefault();
            wizytaDb.Opis = opisWizytyTextBox.Text;
            dataBaseContext.SaveChanges();
            Close();
        }

        private void WypiszSkierowanieBtn_Click(object sender, RoutedEventArgs e)
        {
            EeferralForm skierowanie = new EeferralForm(wizyta1);
            skierowanie.ShowDialog();

        }
    }
}
