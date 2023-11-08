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
    /// Логика взаимодействия для MainWindow.xaml
    /// Главное окно от которого идут различные страницы
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameObj.frameObj = FrmMain;
            FrmMain.Navigate(new MainPage(this));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameObj.frameObj.GoBack();
            }
            catch
            {
                MessageBox.Show("Некуда");
            }
        }
    }
}
