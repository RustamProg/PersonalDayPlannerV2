using PersonalDayPlannerV2.db_models;
using PersonalDayPlannerV2.UI_elements;
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
using System.Windows.Shapes;

namespace PersonalDayPlannerV2
{
    /// <summary>
    /// Логика взаимодействия для PlannerWindow.xaml
    /// </summary>
    public partial class PlannerWindow : Window
    {
        private string CurrentYear { get; set; }    
        private string CurrentMonth { get; set; }
        private int UserID { get; set; }
        private Dictionary<string, int> months = new Dictionary<string, int>
        {
            {"Январь", 1 },
            {"Февраль", 2 },
            {"Март", 3 },
            {"Апрель", 4 },
            {"Май", 5 },
            {"Июнь", 6 },
            {"Июль", 7 },
            {"Август", 8 },
            {"Сентябрь", 9 },
            {"Октябрь", 10 },
            {"Ноябрь", 11 },
            {"Декабрь", 12 },
        };
        ApplicationContext db;

        public PlannerWindow(User user)
        {
            InitializeComponent();
            this.DataContext = user;            
            UserID = user.id;

            db = new ApplicationContext();
            db.Notes.Load();

            DateTime today = DateTime.Now;
            CurrentMonth = today.ToString("MMMM");
            CurrentYear = today.ToString("yyyy");

            int month = months[CurrentMonth];
            int year = int.Parse(CurrentYear);
            MakeDaysGrid(DateTime.DaysInMonth(year, month), month, year);
        }

        private void MakeDaysGrid(int days, int month, int year)
        {
            bigCalendar.Children.Clear();
            monthHeader.Text = CurrentMonth;
            yearHeader.Text = CurrentYear + " год";

            for (int day = 1; day <= days; day++)
            {               
                StackPanel onButtonStackPanel = new StackPanel()
                {
                    Orientation = Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Left
                };               

                TextBlock monthDayText = new TextBlock()
                {
                    Text = day.ToString(),
                };

                onButtonStackPanel.Children.Add(monthDayText);               

                var day_info = db.Notes.Where(v => v.Day == day && v.Month == month && v.Year == year && v.User_ID == UserID).ToList();
                if (day_info.Count > 0)
                {
                    StackPanel innerDotsPanel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };
                    for (int notes = 0; notes < day_info.Count; notes++)
                    {                       
                        Ellipse taskEllipse = new Ellipse()
                        {
                            Width = 10,
                            Height = 10,
                            Stroke = Brushes.Red,
                            Fill = Brushes.Red,
                            Margin = new Thickness(8)
                        };
                        innerDotsPanel.Children.Add(taskEllipse);                       
                    }
                    onButtonStackPanel.Children.Add(innerDotsPanel);
                }

                Button calendarButton = new Button()
                {
                    Content = onButtonStackPanel,
                    Style = (Style)FindResource("calendarDayButton"),
                };
                calendarButton.Tag = day;
                calendarButton.Click += (s, e) => OpenModalDayWindow(s, e, day_info);
                bigCalendar.Children.Add(calendarButton);      
            }

        }

        public void OpenModalDayWindow(object sender, RoutedEventArgs e, List<Note> notes_list)
        {           
            DayPanel dayPanel = new DayPanel(notes_list);
            dayPanel.UserID = UserID;
            dayPanel.Day = (int)((Button)sender).Tag;
            dayPanel.Month = months[CurrentMonth];
            dayPanel.Year = int.Parse(CurrentYear);
            dayPanel.ShowDialog();
            if (dayPanel.DialogResult == true)
            {
                int month = months[CurrentMonth];
                int year = int.Parse(CurrentYear);
                MakeDaysGrid(DateTime.DaysInMonth(year, month), month, year);
            }
        }

        private void OpenModalDatePickModal(object sender, RoutedEventArgs e)
        {
            DatePickWindowModal datePickWindowModal = new DatePickWindowModal();
            if (datePickWindowModal.ShowDialog() == true)
            {
                CurrentMonth = datePickWindowModal.SelectedMonth;
                CurrentYear = datePickWindowModal.SelectedYear;
            }

            int month = months[CurrentMonth];
            int year = int.Parse(CurrentYear);
            MakeDaysGrid(DateTime.DaysInMonth(year, month), month, year);
        }

        public void SetPickedDate(string year, string month)
        {

        }

        private void Exit_Program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
