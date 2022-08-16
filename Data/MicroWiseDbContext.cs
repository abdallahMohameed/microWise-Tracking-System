using Microsoft.EntityFrameworkCore;

namespace microWise_Tracking_System.Models
{
    public class MicroWiseDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<EmployeeMonth> EmployeesMonth { get; set; }
        public DbSet<dailyTraking> DailyTraking { get; set; }
        public DbSet<Month> months { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee
            modelBuilder.Entity<Employee>(a =>
            {
                a.HasKey(s => s.Id);
            });


            //EmployeeMonth
            modelBuilder.Entity<EmployeeMonth>(a =>
            {
                a.HasKey(a=>new {a.monthId,a.employeeId});
            });




            //Team
            modelBuilder.Entity<Team>(a =>
            {
                a.HasKey(a=>a.Id);
            });



            //DailytTraking

            modelBuilder.Entity<dailyTraking>(a =>
            {
                a.HasKey(a => new {a.employeeID,a.date});
            });



            //month
            modelBuilder.Entity<Month>(a =>
            {
                a.HasKey(a => new {a.id});

            });
            base.OnModelCreating(modelBuilder);
        }


    }
}
