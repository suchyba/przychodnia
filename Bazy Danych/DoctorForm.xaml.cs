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
    /// Interaction logic for DoctorForm.xaml
    /// </summary>
    public partial class DoctorForm : Window
    {
        public long PESELDoktora { get; set; }

        public DetailsDoctorForm DetailsDoctorForm { get; set; }
        public DoctorForm thisForm { get; set; }
        public DoctorForm()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
        public DoctorForm(long pesel)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            PESELDoktora = pesel;
            wczytajWizyty();
            thisForm = this;
        }
        private void wczytajWizyty()
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            var wizyty = dataBaseContext.Wizyty.Include("pacjent").Include("lekarz").Where(p => p.lekarz.PESEL == PESELDoktora);

            wizytyListBox.ItemsSource = wizyty.ToList();
            wizytyListBox.UpdateLayout();
        }

        private void wizytyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Wizyta wybrany = (Wizyta)wizytyListBox.SelectedItem;
            peselSzczegolyLabel.Text = wybrany.pacjent.PESEL.ToString();
            imieSzczegolyLabel.Text = wybrany.pacjent.Imie.ToString();
            nazwiskoSzczegolyLabel.Text = wybrany.pacjent.Nazwisko.ToString();
            DataSzczegolyLabel.Text = wybrany.Data.ToString();
        }

        private void PrzyjmujBtn_Click(object sender, RoutedEventArgs e)
        {
            Wizyta wybrany = (Wizyta)wizytyListBox.SelectedItem;
            if(wybrany == null) { return; }
            DetailsDoctorForm = new DetailsDoctorForm(wybrany,wybrany.pacjent);
            Close();
            DetailsDoctorForm.ShowDialog();
            DoctorForm w = new DoctorForm(PESELDoktora);
            w.ShowDialog();
        }
    }
}
