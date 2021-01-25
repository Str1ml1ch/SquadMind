using Microsoft.EntityFrameworkCore;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Data;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleSettings> RoleSettings { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
           // Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserType.SetupUser(modelBuilder);
            SettingsType.SetupSettings(modelBuilder);
            RoleType.SetupRole(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
