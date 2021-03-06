// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrismCore.Server.Common.Conntext;

namespace PrismCore.Server.Common.Migrations
{
    [DbContext(typeof(EFCodeContext))]
    [Migration("20220112143816_updateUserModel")]
    partial class updateUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PrismCore.Server.Common.Models.MenuInfo", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("menu_id")
                        .UseIdentityColumn();

                    b.Property<int>("Index")
                        .HasColumnType("int")
                        .HasColumnName("index");

                    b.Property<string>("MenuHeader")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("menu_header");

                    b.Property<string>("MenuIcon")
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("menu_icon");

                    b.Property<int>("MenuType")
                        .HasColumnType("int")
                        .HasColumnName("menu_type");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parent_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("TargetView")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("target_view");

                    b.HasKey("MenuId");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("PrismCore.Server.Common.Models.RoleInfo", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("PrismCore.Server.Common.Models.RoleMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int")
                        .HasColumnName("menu_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("MenuId", "RoleId");

                    b.ToTable("role_menu");
                });

            modelBuilder.Entity("PrismCore.Server.Common.Models.SysUserInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("sys_user_info");
                });

            modelBuilder.Entity("PrismCore.Server.Common.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("user_role");
                });
#pragma warning restore 612, 618
        }
    }
}
