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
    /// Logika interakcji dla klasy DodajWizyteForm.xaml
    /// </summary>
    public partial class DodajWizyteForm : Window
    {
        public DodajWizyteForm()
        {
            InitializeComponent();
        }
        /*private void WizytaBtn_Click(object sender, RoutedEventArgs e)
        {
            long PESELPacjeta;
            long PESELDoktora;
            DateTime dataWizyty;

            if (!long.TryParse(PESELTextBox.Text, out PESELPacjeta))
            {
                wizytaLabel.Content = "PESEL pacjeta jest nie prawidłowy";
                return;
            }

            if (!long.TryParse(DoctorPESELTextBox.Text, out PESELDoktora))
            {
                wizytaLabel.Content = "PESEL doktora jest nie prawidłowy";
                return;

            }
            if (DateTextBox.Value == null)
            {
                wizytaLabel.Content = "Nie wybrano daty";
                return;
            }
            dataWizyty = (DateTime)DateTextBox.Value;

            string opisWizyty = opisTextBox.Text;

            using DataBaseContext dataBaseContext = new DataBaseContext();

            var lekarz = dataBaseContext.Lekarze.Where(p => p.PESEL == PESELDoktora);
            var pacjent = dataBaseContext.Pacjeci.Where(p => p.PESEL == PESELPacjeta);

            //Wizyta wizyta = new Wizyta
            //{
            //    Data = new DateTime(DateTextBox.ToString())
            //}
            if (lekarz.Count() > 1 || pacjent.Count() > 1)
            {
                return;
            }
            if (lekarz.Count() == 1 && pacjent.Count() == 1)
            {
                Wizyta wizyta = new Wizyta
                {
                    Data = dataWizyty,
                    Opis = opisWizyty,
                    lekarz = lekarz.First(),
                    pacjent = pacjent.First()
                };
                lekarz.First().wizyty.Add(wizyta);
                pacjent.First().wizyty.Add(wizyta);
                wizytaLabel.Content = "Dodano wizyte";
            }
            dataBaseContext.SaveChanges();
        }*/
    }
}
