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
        public Pacjent pacjent { get; set; }
        public Pielegniarka ObecnaPielegniarka { get; set; }

        public NurseForm(Pielegniarka pielegniarka)
        {
            InitializeComponent();
            ObecnaPielegniarka = pielegniarka;
            ZabiegiListBox.ItemsSource = pielegniarka.zabiegi;
            PielengniarkaLabel.Content = pielegniarka.Imie + " " + pielegniarka.Nazwisko;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Visibility = Visibility.Collapsed;
            PeselTextBox.ClearValue(TextBox.BorderBrushProperty);
            long PESELPacjeta;

            using DataBaseContext dataBaseContext = new DataBaseContext();
            IQueryable<Pacjent> Wynik = null;
            if (!String.IsNullOrEmpty(PeselTextBox.Text) && long.TryParse(PeselTextBox.Text, out PESELPacjeta))
            {
                Wynik = dataBaseContext.Pacjeci.Include("adres").Where(p => p.PESEL == PESELPacjeta).OrderBy(p => p.PESEL);
            }
            else
            {
                PeselTextBox.BorderBrush = Brushes.Red;
            }
            pacjent = Wynik?.FirstOrDefault();
            if (pacjent != null)
            {
                ImieTextBox.Text = pacjent.Imie;
                NazwiskoTextBox.Text = pacjent.Nazwisko;
                MiastoTextBox.Text = pacjent.adres.Miasto;
                SearchPacjentGroupBox.IsEnabled = true;
            }
            else
            {
                ImieTextBox.Text = "";
                NazwiskoTextBox.Text = "";
                MiastoTextBox.Text = "";
                SearchPacjentGroupBox.IsEnabled = false;
                ErrorLabel.Content = "Nie ma takiego pacjenta!";
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }

        private void DodajWizyteButton_Click(object sender, RoutedEventArgs e)
        {
            DodajWizyteForm w = new DodajWizyteForm(pacjent);
            w.ShowDialog();
        }

        private void AddPacjentButton_Click(object sender, RoutedEventArgs e)
        {
            DodajPacjentaForm w = new DodajPacjentaForm();
            w.Owner = this;
            w.ShowDialog();
            if (pacjent != null)
            {
                ImieTextBox.Text = pacjent.Imie;
                NazwiskoTextBox.Text = pacjent.Nazwisko;
                MiastoTextBox.Text = pacjent.adres.Miasto;
                SearchPacjentGroupBox.IsEnabled = true;
            }
        }
    }
}
