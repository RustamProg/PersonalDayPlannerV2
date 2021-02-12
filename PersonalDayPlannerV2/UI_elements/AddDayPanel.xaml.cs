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
using System.Windows.Shapes;

namespace PersonalDayPlannerV2.UI_elements
{
    /// <summary>
    /// Логика взаимодействия для AddDayPanel.xaml
    /// </summary>
    public partial class AddDayPanel : Window
    {
        public int Month = 1;
        public int Day = 1;
        public int Year = 2001;
        public int UserID { get; set; }
        ApplicationContext db;       
        public AddDayPanel()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Notes.Load();
        }

        private void saveNote_Click(object sender, RoutedEventArgs e)
        {
            DateTime added_date = DateTime.Now;
            DateTime to_date = new DateTime(Year, Month, Day);

            Note new_note = new Note()
            {
                Title = titleTextField.Text,
                TextBody = descriptionTextField.Text,
                Is_Done = 0,
                Day = to_date.Day,
                Month = to_date.Month,
                Year = to_date.Year,
                To_Day = added_date.Day,
                To_Month = added_date.Month,
                To_Year = added_date.Year,
                User_ID = UserID
            };
            db.Notes.Add(new_note);
            db.SaveChanges();

            this.DialogResult = true;
        }
    }
}
