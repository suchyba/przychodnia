﻿using Bazy_Danych.Data;
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
        public DoctorForm()
        {
            InitializeComponent();
        }
        public DoctorForm(long pesel)
        {
            InitializeComponent();
            PESELDoktora = pesel;
            wczytajWizyty();
        }
        private void wczytajWizyty()
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            var wizyty = dataBaseContext.Wizyty.Include("pacjent").Where(p => p.lekarz.PESEL == PESELDoktora);

            wizytyListBox.ItemsSource = wizyty.ToList();
            wizytyListBox.UpdateLayout();
        }

        private void wizytyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Wizyta wybrany = (Wizyta)wizytyListBox.SelectedItem;
            peselSzczegolyLabel.Content = wybrany.pacjent.PESEL;
            imieSzczegolyLabel.Content = wybrany.pacjent.Imie;
            nazwiskoSzczegolyLabel.Content = wybrany.pacjent.Nazwisko;
            DataSzczegolyLabel.Content = wybrany.Data;
        }

        private void PrzyjmujBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}