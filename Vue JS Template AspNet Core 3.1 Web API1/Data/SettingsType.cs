using Microsoft.EntityFrameworkCore;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Data
{
    public class SettingsType
    {
        public static void SetupSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Settings>()
                .HasKey(u => u.SettingsId);

            modelBuilder.Entity<Settings>()
                .Property(u => u.SettingsName)
                .HasMaxLength(255)
                .IsRequired(true);

            modelBuilder.Entity<Settings>()
                .HasIndex(u => u.SettingsName)
                .IsUnique(true);

            modelBuilder.Entity<RoleSettings>()
    .HasKey(bc => new { bc.UserId, bc.SettingsId });

            modelBuilder.Entity<RoleSettings>()
    .HasOne(bc => bc.User)
    .WithMany(b => b.RoleSettingses)
    .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<RoleSettings>()
              .HasOne(bc => bc.Settings)
              .WithMany(b => b.RoleSettingses)
              .HasForeignKey(bc => bc.SettingsId);
        }
    }
}
