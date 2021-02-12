using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDayPlannerV2.db_models
{
    public class Note
    {
        private string title, textBody;
        private int is_done, day, month, year, to_day, to_month, to_year, user_id;

        [Key]
        public int id { get; set; }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string TextBody
        {
            get { return textBody; }
            set { textBody = value; }
        }

        public int Is_Done
        {
            get { return is_done; }
            set { is_done = value; }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int To_Day
        {
            get { return to_day; }
            set { to_day = value; }
        }

        public int To_Month
        {
            get { return to_month; }
            set { to_month = value; }
        }

        public int To_Year
        {
            get { return to_year; }
            set { to_year = value; }
        }

        public int User_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public override string ToString()
        {
            return $"{id} - {Title} - {TextBody}";
        }
    }
}
