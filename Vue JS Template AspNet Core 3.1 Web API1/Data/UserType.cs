using Microsoft.EntityFrameworkCore;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Data
{
    public class UserType
    {
        public static void SetupUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Skype)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Signature)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(255)
                .IsRequired(true);

            modelBuilder.Entity<User>()
                .Property(u => u.Image)
                .HasMaxLength(65535)
                .HasDefaultValue(null);


        }
    }
}
