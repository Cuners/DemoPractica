using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DEmoPrac.Models;
namespace DEmoPrac
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorPage.xaml
    /// Вывод времени дня, фотографии, отчества пользователя, а также переходы
    /// </summary>
    public partial class OrganizatorPage : Page
    {

        public OrganizatorPage(Polzovateli polzovateli)
        {
            InitializeComponent();
            TimeSpan timeMorn1 = new TimeSpan(9, 0, 0);
            TimeSpan timeMorn2=new TimeSpan(11, 0, 0);
            TimeSpan timeDay1=new TimeSpan(11, 0, 1);
            TimeSpan timeDay2=new TimeSpan(18, 0, 0);
            TimeSpan timeEvening1= new TimeSpan(18, 0, 1);
            TimeSpan timeEvening2=new TimeSpan(24, 0, 0);
            TimeSpan timeNight1=new TimeSpan(0, 0, 1);
            TimeSpan timeNight2=new TimeSpan(8, 5, 9);
            var time=DateTime.Now.TimeOfDay;
            if (time>=timeMorn1 && time<=timeMorn2){
                TimeNow.Content = "Доброе утро!";
            }
            else if(time>=timeDay1 && time <= timeDay2)
            {
                TimeNow.Content = "Добрый день!";
            }
            else if (time>=timeEvening1 && time<=timeEvening2){
                TimeNow.Content = "Добрый вечер!";
            }
            else if(time>=timeNight1 && time <= timeNight2)
            {
                TimeNow.Content = "Доброй ночи!";
            }
            StringImage.Text = ".//Polzovateli/" + polzovateli.Photo;
            Otchestvo.Content = polzovateli.Ima;
            using(PracticaModeratorEntitie practica=new PracticaModeratorEntitie())
            {
                foreach(Polzovatel_pol pol in practica.Polzovatel_pol)
                {
                    if (pol.ID_polzovatelya == polzovateli.ID)
                    {
                        if (pol.ID_pola == 1)
                        {
                            Pol.Content = "Mrs";
                        }
                        else
                        {
                            Pol.Content = "Ms";
                        }
                        
                    }
                }
            }
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Профиль");
        }

        private void MeropriatiaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Мероприятия");
        }

        private void UchastnikiButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Участники");
        }

        private void JuriButton_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameObj.Navigate(new RegistrationJuriMod());
        }
    }
}
