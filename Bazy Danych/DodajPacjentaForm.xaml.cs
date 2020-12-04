using Bazy_Danych.Data;
using Bazy_Danych.Model;
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
        private void AddPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            NumerMieszkaniaTextBox.ClearValue(TextBox.BorderBrushProperty);
            NumerDomuTextBox.ClearValue(TextBox.BorderBrushProperty);
            ImieTextBox.ClearValue(TextBox.BorderBrushProperty);
            NazwiskoTextBox.ClearValue(TextBox.BorderBrushProperty);
            UlicaTextBox.ClearValue(TextBox.BorderBrushProperty);
            MiastoTextBox.ClearValue(TextBox.BorderBrushProperty);
            KodTextBox.ClearValue(TextBox.BorderBrushProperty);
            PESELTextBox.ClearValue(TextBox.BorderBrushProperty);

            long PESELPacjeta;
            string imie;
            string nazwisko;
            string miasto;
            string ulica;
            string kodPocztowy;
            int nrDomu;
            int numerMieszkania = -1;

            bool blad = false;
            if (!long.TryParse(PESELTextBox.Text, out PESELPacjeta))
            {
                PESELTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            imie = ImieTextBox.Text;
            nazwisko = NazwiskoTextBox.Text;
            miasto = MiastoTextBox.Text;
            ulica = UlicaTextBox.Text;
            kodPocztowy = KodTextBox.Text;

            if (!int.TryParse(NumerDomuTextBox.Text, out nrDomu))
            {
                NumerDomuTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (!String.IsNullOrEmpty(NumerMieszkaniaTextBox.Text))
            {
                if (!int.TryParse(NumerMieszkaniaTextBox.Text, out numerMieszkania))
                {
                    NumerMieszkaniaTextBox.BorderBrush = Brushes.Red;
                    blad = true;
                }
            }
            if(String.IsNullOrEmpty(ImieTextBox.Text))
            {
                ImieTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (String.IsNullOrEmpty(NazwiskoTextBox.Text))
            {
                NazwiskoTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (String.IsNullOrEmpty(MiastoTextBox.Text))
            {
                MiastoTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (String.IsNullOrEmpty(KodTextBox.Text) || !KodTextBox.Text.Contains("-"))
            {
                KodTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (String.IsNullOrEmpty(NumerDomuTextBox.Text))
            {
                NumerDomuTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (String.IsNullOrEmpty(UlicaTextBox.Text))
            {
                UlicaTextBox.BorderBrush = Brushes.Red;
                blad = true;
            }
            if (blad)
                return;


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
            dataBaseContext.Add(pacjent);
            dataBaseContext.SaveChanges();

            MessageBox.Show("Dodano pacjenta", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            (this.Owner as NurseForm).pacjent = pacjent;
            Close();
        }
    }
}
