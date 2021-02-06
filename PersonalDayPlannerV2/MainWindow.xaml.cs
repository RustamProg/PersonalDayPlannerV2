using PersonalDayPlannerV2.db_models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PersonalDayPlannerV2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {           
            InitializeComponent();
            db = new ApplicationContext();
            db.Users.Load();
        }

        private void close_Program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void open_Registration(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }

        private void login_Profile(object sender, RoutedEventArgs e)
        {
            User user = db.Users.Find(usernameField.Text);
            if (user != null)
            {
                if (user.Password == passwordField.Password)
                {
                    MessageBox.Show($"Добро пожаловать, {user.First_name} {user.Last_name}", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
                    PlannerWindow plannerWindow = new PlannerWindow();
                    plannerWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }              
            else
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
