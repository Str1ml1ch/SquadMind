using Microsoft.EntityFrameworkCore;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Data
{
    public class RoleType
    {
        public static void SetupRole(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Role>()
          // .HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleName)
                .IsUnique(true);

            modelBuilder.Entity<Role>()
            .Property(u => u.RoleName)
            .IsRequired(true)
            .HasMaxLength(255);
        }
    }
}
