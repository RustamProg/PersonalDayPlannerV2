using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDayPlannerV2.db_models
{
    public class User
    {       
        private string username, password, first_name, last_name;
       
        public int id { get; set; }
        
        [Key]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public override string ToString()
        {
            return $"{id.ToString()} - {username} - {password} - {first_name} - {last_name}";
        }
    }
}
