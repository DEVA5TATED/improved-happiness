using MyDem.Model;
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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        library_dbEntities library = new library_dbEntities();
        public RegWindow()
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
                    Model.Reader reader = new Model.Reader();
                    User user = new User();

                    reader.surname = fam_box.Text;
                    reader.name = name_box.Text;
                    reader.lastname = lastname_box.Text;

                    library.Reader.Add(reader);
                    library.SaveChanges();

                    user.login = login_box.Text;
                    user.password = password_box.Password;
                    user.role_id = 2;
                    var currentUser = library.Reader.ToList();
                    user.reader_id = currentUser.Last().reader_id;

                    library.User.Add(user);
                    library.SaveChanges();

                    MessageBox.Show("Вы успешно зарегистрировались", "Победа!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
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
            if (string.IsNullOrEmpty(fam_box.Text))
            {
                error.AppendLine("Введите фамилию");
            }
            if (string.IsNullOrEmpty(name_box.Text))
            {
                error.AppendLine("Введите имя");
            }
            if (string.IsNullOrEmpty(lastname_box.Text))
            {
                error.AppendLine("Введите отчество");
            }
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
