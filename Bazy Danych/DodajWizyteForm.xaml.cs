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
using Xceed.Wpf.Toolkit;

namespace Bazy_Danych
{
    /// <summary>
    /// Logika interakcji dla klasy DodajWizyteForm.xaml
    /// </summary>
    public partial class DodajWizyteForm : Window
    {
        public Pacjent ObecnyPacjent { get; set; }
        public DodajWizyteForm(Pacjent pacjent)
        {
            InitializeComponent();
            ObecnyPacjent = pacjent;

            using DataBaseContext dataBaseContext = new DataBaseContext();
            dataBaseContext.Lekarze.Load();

            LekarzComboBox.ItemsSource = dataBaseContext.Lekarze.Local.ToObservableCollection();
            LekarzComboBox.Items.Refresh();

            LekarzComboBox.SelectedIndex = 0;

            PacjentTextBox.Text = pacjent.Imie + " " + pacjent.Nazwisko;
        }
        private void WizytaBtn_Click(object sender, RoutedEventArgs e)
        {
            DataDatePicker.ClearValue(DateTimePicker.BorderBrushProperty);
            LekarzComboBox.ClearValue(ComboBox.BackgroundProperty);
            
            DateTime? dataWizyty = null;

            bool blad = false;
            if (DataDatePicker.Value == null)
            {
                DataDatePicker.BorderBrush = Brushes.Red;
                blad = true;
            }
            else
                dataWizyty = (DateTime)DataDatePicker.Value;

            using DataBaseContext dataBaseContext = new DataBaseContext();

            Lekarz lekarzCombo = LekarzComboBox.SelectedItem as Lekarz;
            Lekarz lekarz = dataBaseContext.Lekarze.Where(l => l.PESEL == lekarzCombo.PESEL).FirstOrDefault();

            Pacjent pacjent = dataBaseContext.Pacjeci.Where(p => p.PESEL == ObecnyPacjent.PESEL).FirstOrDefault();

            if (lekarz == null)
            {
                blad = true;
            }
            if (blad)
                return;

            Wizyta wizyta = new Wizyta
            {
                Data = (DateTime)dataWizyty,
                Opis = null,
                lekarz = lekarz,
                pacjent = pacjent
            };


            dataBaseContext.Wizyty.Add(wizyta);
            dataBaseContext.SaveChanges();

            System.Windows.MessageBox.Show("Dodano wizytę", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
