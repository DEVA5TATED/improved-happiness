using MyDem.Model;
using MyDem.MyWindows.Admin;
using MyDem.MyWindows.Reader;
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
using System.Windows.Shapes;

namespace MyDem.MyWindows.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        library_dbEntities library = new library_dbEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {
                    User user = library.User.FirstOrDefault(item => item.login == login_box.Text && item.password == password_box.Password);
                    if(user != null)
                    {
                        if(user.role_id == 1)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            this.Close();

                        }
                        if(user.role_id == 2)
                        {
                            ReaderWindow readerWindow = new ReaderWindow();
                            readerWindow.Show();
                            this.Close();
                        }
                        if(user.role_id == 3)
                        {
                            EmloyeeWindow
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка!");
                }
            }
        }

        private bool isChecked()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(login_box.Text))
            {
                error.AppendLine("Введите логин");
            }
            if (string.IsNullOrEmpty(password_box.Password))
            {
                error.AppendLine("Введите пароль");
            }
            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
