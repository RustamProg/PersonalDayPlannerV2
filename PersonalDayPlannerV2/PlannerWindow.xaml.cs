using PersonalDayPlannerV2.UI_elements;
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
    /// Логика взаимодействия для PlannerWindow.xaml
    /// </summary>
    public partial class PlannerWindow : Window
    {
        private string CurrentYear { get; set; }
        private string CurrentMonth { get; set; }
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

        public PlannerWindow()
        {
            InitializeComponent();

            CurrentMonth = "Январь";
            CurrentYear = "2021";

            int month = months[CurrentMonth];
            int year = int.Parse(CurrentYear);

            MakeDaysGrid(DateTime.DaysInMonth(year, month));
        }

        private void MakeDaysGrid(int days)
        {
            bigCalendar.Children.Clear();

            for (int i = 1; i <= days; i++)
            {
                Button calendarButton = new Button()
                {
                    Content = i.ToString(),
                    Style = (Style)FindResource("calendarDayButton"),
                };

                calendarButton.Click += OpenModalDayWindow;
                bigCalendar.Children.Add(calendarButton);
            }

        }

        public void OpenModalDayWindow(object sender, RoutedEventArgs e)
        {
            DayPanel dayPanel = new DayPanel()
            {
                Header = "Empty title",
                Date = "01-01-2002",
                TextBody = "Day panel sample",
                BoxColor = "Red",
                IsDone = "False",
                IsInProgress = "True"
            };
            dayPanel.ShowDialog();
        }

        private void OpenModalDatePickModal(object sender, RoutedEventArgs e)
        {
            DatePickWindowModal datePickWindowModal = new DatePickWindowModal();
            if (datePickWindowModal.ShowDialog() == true)
            {
                CurrentMonth = datePickWindowModal.SelectedMonth;
                CurrentYear = datePickWindowModal.SelectedYear;
                MessageBox.Show(CurrentMonth + CurrentYear);
            }

            int month = months[CurrentMonth];
            int year = int.Parse(CurrentYear);

            MakeDaysGrid(DateTime.DaysInMonth(year, month));
        }

        public void SetPickedDate(string year, string month)
        {

        }

        private void Exit_Program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
