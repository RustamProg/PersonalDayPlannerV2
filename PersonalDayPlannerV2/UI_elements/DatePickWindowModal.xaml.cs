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
    /// Логика взаимодействия для DatePickWindowModal.xaml
    /// </summary>
    public partial class DatePickWindowModal : Window
    {
        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }
        public DatePickWindowModal()
        {
            InitializeComponent();
        }

        private void Month_Click(object sender, RoutedEventArgs e)
        {
            Button monthButton = (Button)sender;
            SelectedMonth = monthButton.Content.ToString();
            SelectedYear = yearComboBox.Text;
            this.DialogResult = true;
        }
    }
}
