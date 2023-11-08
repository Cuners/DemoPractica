using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DEmoPrac.Models;
namespace DEmoPrac
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// Логика авторизации и сохранение данных в properties на программном уровне
    /// А также блокировка окна
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        DispatcherTimer timer;
        bool flag = false;
        MainWindow mainWindow;
        public AuthorizationPage(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += new EventHandler(timer_Tick);
            LoadSavedText();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            AuthPage.IsEnabled = true;
            mainWindow.BackButton.IsEnabled = true;
            PopitkiVvod.counter = 1;
            timer.Stop();
        }
        private void Disable()
        {
            AuthPage.IsEnabled = false;
            mainWindow.BackButton.IsEnabled = false;
            timer.Start();
        }
        
        private void LoadSavedText()
        {

                if (Properties.Settings.Default.IdTextBox != string.Empty)
                {
                    IdNumberBox.Text = Properties.Settings.Default.IdTextBox;
                }
                if (Properties.Settings.Default.PassTextBox != string.Empty)
                {
                    PasswordBox.Password = Properties.Settings.Default.PassTextBox;
                    TextPassBox.Text = Properties.Settings.Default.PassTextBox;
                }
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string pass;
            if(CheckPass.IsChecked== true)
            {
                pass = TextPassBox.Text;
            }
            else
            {
                pass = PasswordBox.Password;
            }
            if (!string.IsNullOrWhiteSpace(IdNumberBox.Text) && !string.IsNullOrWhiteSpace(pass) && PopitkiVvod.counter<3)
            {
                using (PracticaModeratorEntitie practica = new PracticaModeratorEntitie())
                {
                    foreach (Polzovatel_role polzovatel_Role in practica.Polzovatel_role)
                    {
                        if (polzovatel_Role.Polzovateli.ID == Convert.ToInt32(IdNumberBox.Text) &&
                            polzovatel_Role.Polzovateli.Password == pass)
                        {
                            flag = true;
                            Properties.Settings.Default.IdTextBox = IdNumberBox.Text;
                            Properties.Settings.Default.PassTextBox = pass;
                            Properties.Settings.Default.Save();
                           
                            if (polzovatel_Role.ID_role == 1)
                            {
                                MessageBox.Show("Участник");
                            }
                            else if (polzovatel_Role.ID_role == 2)
                            {
                                MessageBox.Show("Модератор");
                            }
                            else if (polzovatel_Role.ID_role == 3)
                            {
                                MessageBox.Show("Добро пожаловать организатор");
                                FrameObj.frameObj.Navigate(new OrganizatorPage(polzovatel_Role.Polzovateli));

                            }
                            else if (polzovatel_Role.ID_role == 4)
                            {
                                MessageBox.Show("Жюри");
                            }
                        }

                       
                    }
                    

                }
            }
            if (PopitkiVvod.counter < 3 && flag == false && !string.IsNullOrWhiteSpace(IdNumberBox.Text) && !string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Id или пароль не верен");
                PopitkiVvod.counter++;
                FrameObj.frameObj.Navigate(new CaptchaPage(mainWindow));

            }
            else if (string.IsNullOrWhiteSpace(IdNumberBox.Text) && PopitkiVvod.counter < 3)
            {
                MessageBox.Show("Id не введен");
                PopitkiVvod.counter++;
                FrameObj.frameObj.Navigate(new CaptchaPage(mainWindow));
            }
            else if (string.IsNullOrWhiteSpace(pass) && PopitkiVvod.counter < 3)
            {
                MessageBox.Show("Password не введен");
                PopitkiVvod.counter++;
                FrameObj.frameObj.Navigate(new CaptchaPage(mainWindow));
            }
            else if (PopitkiVvod.counter >= 3)
            {
                Disable();
                MessageBox.Show("Id или пароль не верен. Лимит ввода превышен");
            }


        }

        private void CheckPass_Checked(object sender, RoutedEventArgs e)
        {
            TextPassBox.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Hidden;
            TextPassBox.Text = PasswordBox.Password;
        }

        private void CheckPass_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
            TextPassBox.Visibility=Visibility.Hidden;
            PasswordBox.Password = TextPassBox.Text;
        }
    }
}
