using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ITIEntity:DbContext
    {
        public virtual DbSet<Instructor> instructor { get; set; }
        public virtual DbSet<Department> department { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<crsCourse> crsCourses { get; set; }
        public virtual DbSet<Trainee> trainee { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public ITIEntity() 
        {
        }
        public ITIEntity(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI_Mix;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
