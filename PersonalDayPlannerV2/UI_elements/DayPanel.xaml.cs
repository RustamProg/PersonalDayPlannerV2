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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalDayPlannerV2.UI_elements
{
    /// <summary>
    /// Логика взаимодействия для DayPanel.xaml
    /// </summary>
    public partial class DayPanel : Window
    {
        public int UserID { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public DayPanel(List<Note> data)
        {
            InitializeComponent();

            if (data.Count > 0)
            {
                foreach (var note in data)
                {
                    Border notesBorder = new Border()
                    {
                        Background = Brushes.AntiqueWhite,
                        CornerRadius = new CornerRadius(7),
                        Margin = new Thickness(20, 0, 20, 10)
                    };

                    StackPanel noteStack = new StackPanel()
                    {
                        Orientation = Orientation.Vertical,
                        Margin = new Thickness(10)
                    };

                    TextBlock header = new TextBlock()
                    {
                        Text = note.Title,
                        FontSize = 22,
                        Margin = new Thickness(0, 0, 0, 10)
                    };

                    TextBlock textbody = new TextBlock()
                    {
                        Text = note.TextBody,
                        FontSize = 14,
                        TextWrapping = TextWrapping.Wrap
                    };
                    DateTime today = new DateTime(note.Year, note.Month, note.Day);
                    TextBlock date = new TextBlock()
                    {
                        Text = today.ToString("D"),
                        FontSize = 12,
                        Margin = new Thickness(0, 20, 0, 0)
                    };

                    noteStack.Children.Add(header);
                    noteStack.Children.Add(textbody);
                    noteStack.Children.Add(date);

                    notesBorder.Child = noteStack;
                    notesScroll.Children.Add(notesBorder);
                }
            }
            else
            {
                Border notesBorder = new Border()
                {
                    Background = Brushes.AntiqueWhite,
                    CornerRadius = new CornerRadius(7),
                    Margin = new Thickness(20, 0, 20, 10),
                };

                StackPanel noteStack = new StackPanel()
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(10)
                };

                TextBlock empty = new TextBlock()
                {
                    Text = "Заметок нет",
                    FontSize = 32,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                noteStack.Children.Add(empty);
                notesBorder.Child = noteStack;
                notesScroll.Children.Add(notesBorder);
            }           
        }


        private void Close_Modal(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Add_Note(object sender, RoutedEventArgs e)
        {
            AddDayPanel addDayPanel = new AddDayPanel();
            addDayPanel.UserID = UserID;
            addDayPanel.Month = Month;
            addDayPanel.Day = Day;
            addDayPanel.Year = Year;
            addDayPanel.ShowDialog();
            if (addDayPanel.DialogResult == true)
            {
                Close_Modal(sender, e);
            }
        }
    }
}
