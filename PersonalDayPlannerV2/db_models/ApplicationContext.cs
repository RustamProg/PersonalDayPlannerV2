using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDayPlannerV2.db_models
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("SqliteConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
