using PersonalDayPlannerV2.db_models;
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

namespace PersonalDayPlannerV2
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ApplicationContext db;
        public RegistrationWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void return_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void create_Profile(object sender, RoutedEventArgs e)
        {
            foreach (var child in fieldsPanel.Children)
            {
                if (child.GetType().Name == "TextBox")
                {
                    TextBox tempTextBlock = (TextBox)child;
                    tempTextBlock.Background = Brushes.White;
                }
            }
            if (regFirstName.Text.Length < 1)
            {
                regFirstName.Background = Brushes.Red;
                MessageBox.Show("Укажите имя", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (regLastName.Text.Length < 1)
            {
                regLastName.Background = Brushes.Red;
                MessageBox.Show("Укажите фамилию", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (regUsername.Text.Length < 8)
            {
                regUsername.Background = Brushes.Red;
                MessageBox.Show("Имя пользователя должно состоять из не менее чем 8 символов", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (regPassword.Password.Length < 8)
            {
                regPassword.Background = Brushes.Red;
                MessageBox.Show("Длина пароля не менее 8 символов", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (regPasswordCommit.Password.Length < 1)
            {
                regPasswordCommit.Background = Brushes.Red;
                MessageBox.Show("Укажите повтор пароля", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (regPasswordCommit.Password != regPassword.Password)
            {
                regPassword.Background = Brushes.Red;
                regPasswordCommit.Background = Brushes.Red;
                MessageBox.Show("Пароли не совпадают", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            User exists_user = db.Users.Find(regUsername.Text);
            if (exists_user == null)
            {
                User new_user = new User()
                {
                    Username = regUsername.Text,
                    Password = regPassword.Password,
                    First_name = regFirstName.Text,
                    Last_name = regLastName.Text
                };

                db.Users.Add(new_user);
                db.SaveChanges();
                MessageBox.Show("Профиль успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                regUsername.Background = Brushes.Red;
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
