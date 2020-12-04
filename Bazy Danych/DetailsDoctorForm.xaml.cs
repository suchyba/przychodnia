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
        public DetailsDoctorForm thisForm { get; set; }
        public DetailsDoctorForm()
        {
            InitializeComponent();
        }
        public DetailsDoctorForm(Wizyta wizyta,Pacjent p1)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pacjent = p1;
            wizyta1 = wizyta;
            wczytajDane();
            thisForm = this;
        }
        private void wczytajDane()
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            Wizyta wizytaDb = dataBaseContext.Wizyty.Where(p => p.ID == wizyta1.ID).FirstOrDefault();
            if(wizytaDb == null) { return; }
            peselSzczegolyLabel.Text = pacjent.PESEL.ToString();
            imieSzczegolyLabel.Text = pacjent.Imie;
            nazwiskoSzczegolyLabel.Text = pacjent.Nazwisko;
            DataSzczegolyLabel.Text = wizytaDb.Data.ToString();
            opisWizytyTextBox.Text = wizytaDb.Opis;
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
            thisForm.Visibility = Visibility.Collapsed;
            skierowanie.ShowDialog();
            thisForm.Visibility = Visibility.Visible;


        }

        private void WypiszRecepteBtn_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionForm recepta = new PrescriptionForm(wizyta1);
            this.Visibility = Visibility.Collapsed;
            recepta.ShowDialog();
            this.Visibility = Visibility.Visible;

        }
    }
}
