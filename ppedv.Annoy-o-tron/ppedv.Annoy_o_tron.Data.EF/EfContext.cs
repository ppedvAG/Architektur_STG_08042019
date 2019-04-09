using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Annoy_o_tron.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Daily> DailyTemplates { get; set; }
        public DbSet<Weekly> WeeklyTemplates { get; set; }
        public DbSet<Template> Templates { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=.;Database=Annoy_dev;Trusted_Connection=true;")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            //vererbung wird als table-per-type gemappt
            modelBuilder.Entity<Template>().ToTable("Templates");
            modelBuilder.Entity<Daily>().ToTable("DailyTemplates");
            modelBuilder.Entity<Weekly>().ToTable("WeeklyTemplates");

            modelBuilder.Entity<Person>().HasMany(x => x.ProcessesAsAssignee).WithMany(x => x.Assignees);//m:n
            modelBuilder.Entity<Person>().HasMany(x => x.ProcessesAsTasker).WithOptional(x => x.Tasker);//1:n

        }
    }
}
