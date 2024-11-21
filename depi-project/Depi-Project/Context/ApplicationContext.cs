using Depi_Project.Models;

using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Depi_Project.IdentityModels;




namespace Depi_Project.context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
       
        public virtual DbSet<Trainee> Trainees { get; set; }
         public virtual DbSet<Subscription> Subscriptions { get; set; }
        

         public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

        public ApplicationContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured) // Only configure if not already configured
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Gym;Integrated Security=true;trustservercertificate=true;");
    }

    optionsBuilder.UseLazyLoadingProxies();
    optionsBuilder.LogTo(log => Debug.WriteLine(log));
    
    base.OnConfiguring(optionsBuilder);
}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
