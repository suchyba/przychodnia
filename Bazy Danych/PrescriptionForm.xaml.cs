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
    /// Interaction logic for PrescriptionForm.xaml
    /// </summary>
    public partial class PrescriptionForm : Window
    {
        public Wizyta wizyta { get; set; }
        public List<Lek> listaLekow1 { get; set; } =
        new List<Lek>();

        public List<Lek> listaLekow2 { get; set; } =
        new List<Lek>();

        public PrescriptionForm thisForm { get; set; }

        public int index { get; set; } = -1;
        public PrescriptionForm()
        {
            InitializeComponent();
        }

        public PrescriptionForm(Wizyta _wizyta)
        {
            InitializeComponent();
            wizyta = _wizyta;
            WczytajDane();
            thisForm = this;
        }

        private void WczytajDane()
        {
            referralNamePatient.Content = wizyta.pacjent.Imie;
            referralSurnamePatient.Content = wizyta.pacjent.Nazwisko;

            referralNameDoctor.Content = wizyta.lekarz.Imie;
            referralSurnameDoctor.Content = wizyta.lekarz.Nazwisko;
        }
        private void DeleteLekBt_Click(object sender, RoutedEventArgs e)
        {
            if(index == -1) { return; }
            listaLekow2.RemoveAt(index);

            listaLekow.Items.RemoveAt(index);
            index = -1;
            listaLekow.UpdateLayout();
        }

        private void WypiszeRecepteBtn_Click(object sender, RoutedEventArgs e)
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            Pacjent pacjentDb = dataBaseContext.Pacjeci.Where(p => p.PESEL == wizyta.pacjent.PESEL).FirstOrDefault();

            Lekarz lekarzDb = dataBaseContext.Lekarze.Where(p => p.PESEL == wizyta.lekarz.PESEL).FirstOrDefault();


            Recepta recepta = new Recepta
            {
                pacjent = pacjentDb,
                lekarz = lekarzDb,
                //leki = listaLekow2
            };

            
            for(int i =0;i< listaLekow2.Count();i++)
            {
                Lek lekDb = dataBaseContext.Leki.Where(p => p.ID == listaLekow2[i].ID).FirstOrDefault();
                LekRecepta lekRecepta = new LekRecepta
                {
                    recepta = recepta,
                    lek = lekDb
                };
                dataBaseContext.LekRecepta.Add(lekRecepta);

            }


            dataBaseContext.Add(recepta);

            dataBaseContext.SaveChanges();
            MessageBoxResult result = MessageBox.Show("Dodano recepte");
        }


        private void WyszukajBtn_Click_1(object sender, RoutedEventArgs e)
        {
            using DataBaseContext dataBaseContext = new DataBaseContext();

            var leki = dataBaseContext.Leki.Where(p => p.Nazwa_leku == nazwaLeku.Text);

            if (leki == null)
            {
                return;
            }
            listaLekow1 = leki.ToList();

            wyszukaneLeki.ItemsSource = listaLekow1;
            wyszukaneLeki.UpdateLayout();
        }

        private void DodajBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Lek l = (Lek)wyszukaneLeki.SelectedItem;
            if (l == null)
            {
                return;
            }
            Lek lek = new Lek
            {
                ID = l.ID,
                Dawkowanie = l.Dawkowanie,
                Cena = l.Cena,
                Nazwa_leku = l.Nazwa_leku
            };

            
            listaLekow2.Add(lek);
            listaLekow.Items.Add(lek);

            listaLekow.UpdateLayout();
        }

        private void listaLekow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = listaLekow.SelectedIndex;
        }
    }
}
