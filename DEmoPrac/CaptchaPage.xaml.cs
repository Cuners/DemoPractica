

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
using System.Windows.Threading;
using DEmoPrac.Models;
namespace DEmoPrac
{
    /// <summary>
    /// Логика взаимодействия для CaptchaPage.xaml
    /// Генерация капчи и сравнение его с вводом и переходом обратно
    /// </summary>
    public partial class CaptchaPage : Page
    {
        MainWindow mainWindow1;
        public CaptchaPage(MainWindow mainWindow)
        {
            InitializeComponent();
            GenerateCaptcha();
           mainWindow1 = mainWindow;
            mainWindow1.BackButton.IsEnabled = false;
            
        }
       
        private void GenerateCaptcha()
        {
            string allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = "";
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[r.Next(0, ar.Length)];
                pwd += temp;
            }
            textBox1.Text = pwd;
        }

        private void CaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == InputCaptcha.Text)
            {
                MessageBox.Show("Капча успешно введена");
                mainWindow1.BackButton.IsEnabled = true;
                FrameObj.frameObj.GoBack();
            }
            
            else
            {
                MessageBox.Show("Ввод неверный");
                GenerateCaptcha();
            }
           
        }
    }
}
