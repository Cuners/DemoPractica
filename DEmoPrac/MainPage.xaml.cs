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
using DEmoPrac.Models;
namespace DEmoPrac
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// Вывод и фильтрация мероприятий
    /// </summary>
    public partial class MainPage : Page
    {
        List<MeropriyatiaMy> meropriyatiaMies = new List<MeropriyatiaMy>();
        MainWindow main1;
        public MainPage(MainWindow main)
        {
            InitializeComponent();
            main1 = main;
            
            using(PracticaModeratorEntitie practica=new PracticaModeratorEntitie())
            {
               
               foreach(Napravleniya napravleniyas in practica.Napravleniya)
                {
                    NapravleniaCombobox.Items.Add(napravleniyas.Napravlenie);
                }
                NapravleniaCombobox.Items.Add("По умолчанию");
               foreach(Meropriyatiye_tip_Meropriyatiya_napravleniye meropriyatiye_Tip_Meropriyatiya_ in practica.Meropriyatiye_tip_Meropriyatiya_napravleniye)
                {
                    MeropriyatiaMy meropriyatiaMy = new MeropriyatiaMy()
                    {
                        Naimenovanie = meropriyatiye_Tip_Meropriyatiya_.Meropriatiya.Naimenovanie,
                        Napravlenie = meropriyatiye_Tip_Meropriyatiya_.Napravleniya.Napravlenie,
                        Date_nachala = (DateTime)meropriyatiye_Tip_Meropriyatiya_.Meropriatiya.Date_nachala,
                        ImageMer = meropriyatiye_Tip_Meropriyatiya_.Meropriatiya.ImagePho
                    };
                    meropriyatiaMies.Add(meropriyatiaMy);
                }
                ListBoxTemplate.ItemsSource = meropriyatiaMies;

            }
        }

        private void ToAuthButton_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameObj.Navigate(new AuthorizationPage(main1));
        }

        private void NapravleniaCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NapravleniaCombobox.SelectedValue.ToString() == "По умолчанию")
            {
                ListBoxTemplate.ItemsSource = meropriyatiaMies;
            }
            else
            {
                ListBoxTemplate.ItemsSource = meropriyatiaMies.Where(x => x.Napravlenie == NapravleniaCombobox.SelectedValue.ToString());
            }
        }
    }
}
