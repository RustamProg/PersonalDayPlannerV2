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

namespace PersonalDayPlannerV2.UI_elements
{
    /// <summary>
    /// Логика взаимодействия для DayPanel.xaml
    /// </summary>
    public partial class DayPanel : Window
    {
        public DayPanel()
        {
            InitializeComponent();
        }

        public string Header { get; set; }
        public string Date { get; set; }
        public string TextBody { get; set; }
        public string BoxColor { get; set; }
        public string IsDone { get; set; }
        public string IsInProgress { get; set; }

        private void Close_Modal(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
