
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using DEmoPrac.Models;
namespace DEmoPrac
{
    /// <summary>
    /// Логика взаимодействия для RegistrationJuriMod.xaml
    /// Ввод данных для жюри/модераторов, а также проверка неправильного ввода
    /// Сохранение данных непосредственно в нашу Базу данных
    /// </summary>
    public partial class RegistrationJuriMod : Page
    {

        public RegistrationJuriMod()
        {
            InitializeComponent();
            
            Random rand = new Random();
            int id = rand.Next(0, 20000);
            using(PracticaModeratorEntitie moderator = new PracticaModeratorEntitie())
            {
                foreach(Polzovateli polzovateli in moderator.Polzovateli)
                {
                    if (polzovateli.ID == id)
                    {
                        id=rand.Next(0,20000);
                    }
                }
                foreach(Poli poli in moderator.Poli)
                {
                    PolCombox.Items.Add(poli.Pol);
                }
                
                
                foreach(Meropriatiya meropriatiya in moderator.Meropriatiya)
                {
                    MeropriyatieComboBox.Items.Add(meropriatiya.Naimenovanie);
                }
                foreach(Napravleniya napravleniya in moderator.Napravleniya)
                {
                    NapravlenieComboBox.Items.Add(napravleniya.Napravlenie);
                }
            }
            RoleCombobox.ItemsSource = new string[]
            {
                "жюри",
                "модератор"
            };
            IdTextBox.Text = id.ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SearchTermTextBox.Text = PasTermBox.Password;
            SearchTermRePasBox.Text = PassRePasBox.Password;
            SearchTermRePasBox.Visibility = Visibility.Visible;
            SearchTermTextBox.Visibility = Visibility.Visible;
            PasTermBox.Visibility = Visibility.Hidden;
            PassRePasBox.Visibility = Visibility.Hidden;
            PasswordWatermark.Visibility = Visibility.Hidden;
            PassReWatermark.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasTermBox.Password = SearchTermTextBox.Text;
            PassRePasBox.Password = SearchTermRePasBox.Text;
            SearchTermRePasBox.Visibility = Visibility.Hidden;
            SearchTermTextBox.Visibility = Visibility.Hidden;
            PasTermBox.Visibility = Visibility.Visible;
            PassRePasBox.Visibility = Visibility.Visible;
            if (PasTermBox.Password.Length > 0)
            {
                PasswordWatermark.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordWatermark.Visibility = Visibility.Visible;
            }
            if (PassRePasBox.Password.Length > 0)
            {
                PassReWatermark.Visibility = Visibility.Hidden;
            }
            else
            {
                PassReWatermark.Visibility = Visibility.Visible;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string password;
            string PIO = PIOTextBox.Text;
            string[] str = PIO.Split(' ');
            string telephone = TelephoneTextBox.Text;
            string pattern = @"[^\w\s]";
            if (PassCheckbox.IsChecked == false)
            {
                password = PasTermBox.Password;
            }
            else
            {
                password=SearchTermTextBox.Text;
            }
            if (string.IsNullOrEmpty(PIOTextBox.Text))
            {
                MessageBox.Show("Вы не написали фамилию");
            }
            else if (string.IsNullOrEmpty(PochtaTextBox.Text))
            {
                MessageBox.Show("Вы не написали почту");
            }
            else if (PolCombox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пол");
            }
            else if (NapravlenieComboBox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали направление");
            }
            else if (RoleCombobox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали роль");
            }
            else if (!TelephoneTextBox.MaskFull)
            {
                MessageBox.Show("Введите телефон полностью");
            }
            else if (!PochtaTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Нет @ в mail");
            }
            else if (str.Length < 3)
            {
                MessageBox.Show("Вы не ввели ФИО до конца");
            }

            else if ((PasTermBox.Password != PassRePasBox.Password) && PassCheckbox.IsChecked == false)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if ((SearchTermTextBox.Text != SearchTermRePasBox.Text) && PassCheckbox.IsChecked == true)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (PasTermBox.Password.Length < 6 && PassCheckbox.IsChecked == false)
            {
                MessageBox.Show("Не хватает символов");
            }
            else if (SearchTermTextBox.Text.Length < 6 && PassCheckbox.IsChecked == true)
            {
                MessageBox.Show("Не хватает символов");
            }

            else
                {
                try
                {
                    bool flagdigit = false;
                    bool flagspec = false;
                    bool flagUp = false;
                    bool flagBot = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (Char.IsDigit(password[i]) == true)
                        {
                            flagdigit = true;
                        }
                        if (Char.IsUpper(password[i]) == true)
                        {
                            flagUp = true;
                        }
                        if (Char.IsLower(password[i]) == true)
                        {
                            flagBot = true;
                        }
                        
                    }
                    
                    if (Regex.IsMatch(password, pattern))
                    {
                         flagspec = true;
                    }
                    if (flagdigit == true && flagspec == true && flagUp == true && flagBot == true)
                    {
                        using (PracticaModeratorEntitie practica = new PracticaModeratorEntitie())
                        {

                            Polzovateli polzovateli = new Polzovateli
                            {
                                ID = Convert.ToInt32(IdTextBox.Text),
                                Ima = str[0],
                                Phamilia = str[1],
                                Otchestvo = str[2],
                                Pochta = PochtaTextBox.Text,
                                Password = password,
                                Telephone = TelephoneTextBox.Text,
                                Data_rozhdenia = null,
                                Photo = null
                            };
                            Poli id = practica.Poli.Where(x => x.Pol == PolCombox.SelectedValue.ToString()).FirstOrDefault();

                            int id_pol = id.ID_pol;
                            Polzovatel_pol polzovatel_Pol = new Polzovatel_pol
                            {
                                ID_polzovatelya = Convert.ToInt32(Convert.ToInt32(IdTextBox.Text)),
                                ID_pola = id_pol
                            };
                            Napravleniya napr = practica.Napravleniya.Where(x => x.Napravlenie == NapravlenieComboBox.SelectedValue.ToString()).FirstOrDefault();
                            Polzovatel_napravlenie polzovatel_Napravlenie = new Polzovatel_napravlenie
                            {
                                ID_napravlenie = napr.ID_napravlenia,
                                ID_polzovatelya = Convert.ToInt32(IdTextBox.Text)
                            };
                            string roles = RoleCombobox.SelectedValue.ToString();
                            Role role = practica.Role.Where(x => x.Roles == roles).FirstOrDefault();
                            Polzovatel_role polzovatel_Role = new Polzovatel_role
                            {
                                ID_polzovatel = Convert.ToInt32(IdTextBox.Text),
                                ID_role = role.ID_role
                            };
                            practica.Polzovateli.Add(polzovateli);
                            practica.Polzovatel_pol.Add(polzovatel_Pol);
                            practica.Polzovatel_napravlenie.Add(polzovatel_Napravlenie);
                            practica.Polzovatel_role.Add(polzovatel_Role);
                            if (CheckMer.IsChecked == true)
                            {
                                Meropriatiya meropriatiya = practica.Meropriatiya.Where(x => x.Naimenovanie == MeropriyatieComboBox.SelectedValue.ToString()).FirstOrDefault();
                                Polzovateli_meropriatiya polzovateli_Meropriatiya = new Polzovateli_meropriatiya
                                {
                                    ID_meropriatia = meropriatiya.ID_meropriatia,
                                    ID_polzovatelya = Convert.ToInt32(IdTextBox.Text)
                                };
                                practica.Polzovateli_meropriatiya.Add(polzovateli_Meropriatiya);
                            }
                            practica.SaveChanges();
                            
                            MessageBox.Show("Данные успешно добавлены");
                            FrameObj.frameObj.GoBack();
                            
                        }
                    }
                    else
                    {
                        if (flagdigit == false)
                        {
                            MessageBox.Show("Не хватает числа в пароле");
                        }
                        else if (flagspec == false)
                        {
                            MessageBox.Show("Не хватает специального символа в пароле");
                        }
                        else if (flagUp == false)
                        {
                            MessageBox.Show("Не хватает заглавной буквы в пароле");
                        }
                        else if (flagBot == false)
                        {
                            MessageBox.Show("Не хватает строчной буквы в пароле");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"
            };
            if (dlg.ShowDialog() == true)
            {
                ImagePhoto.Source=new BitmapImage(new Uri(dlg.FileName));
            }
            else
            {
                MessageBox.Show("Не удалось загрузить фото");
            }
            
        }

        private void OtmenaButton_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameObj.GoBack();
        }

        private void PasTermBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasTermBox.Password.Length > 0)
            {
                PasswordWatermark.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordWatermark.Visibility = Visibility.Visible;
            }
        }

        private void PassRePasBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassRePasBox.Password.Length > 0)
            {
                PassReWatermark.Visibility = Visibility.Hidden;
            }
            else
            {
                PassReWatermark.Visibility=Visibility.Visible;
            }
        }

    }
}
