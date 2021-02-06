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
        public PlannerWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 31; i++)
            {
                Button calendarButton = new Button()
                {
                    Content = i.ToString(),
                    Style = (Style)FindResource("calendarDayButton")
                };
                bigCalendar.Children.Add(calendarButton);
            }
        }
    }
}
