using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using PrismCore.Server.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Common.Conntext
{
    public class EFCodeContext : DbContext
    {
        public DbSet<SysUserInfo> SysUserInfos { get; set; }
        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection1"));


           
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //联合主键设置
            modelBuilder.Entity<RoleMenu>().HasKey(pk => new { pk.MenuId, pk.RoleId });
            modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserId, pk.RoleId });
            //菜单中的字体图标值转换
            ValueConverter iconValueConverter = new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)v.ToCharArray()[0]).ToString("x"),
                v => v == null ? "" : ((char)int.Parse(v, System.Globalization.NumberStyles.HexNumber)).ToString()
                );
            modelBuilder.Entity<MenuInfo>().Property(p => p.MenuIcon).HasConversion(iconValueConverter);
        }
    }
}
