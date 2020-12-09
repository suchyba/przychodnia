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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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
                    nurseForm = new NurseForm(user2);
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
    }
}
