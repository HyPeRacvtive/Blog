using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text;

namespace Blog.Data.Concrete.EFCore.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.Descreption).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500);
            builder.ToTable("Users");

            builder.HasData(
                new User
                {
                    Id = 1,
                    RoleId = 1,
                    FirstName = "Mehmet",
                    LastName = "Gön",
                    UserName = "hyperprince",
                    Email = "mehmetgon@hotmail.com",
                    Descreption = "Bu Programın Yazarı",
                    PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"),//admin123                             
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Admin Kullanıcısı",
                    Picture= "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
                },
                new User
                {
                    Id = 2,
                    RoleId = 2,
                    FirstName = "Vehbi İlkkan",
                    LastName = "Memili",
                    UserName = "ilkkanml",
                    Email = "ilkkanml@outlook.com",
                    Descreption = "Bu Programın Yazarının arkadaşı",
                    PasswordHash = Encoding.ASCII.GetBytes("4acb4bc224acbbe3c2bfdcaa39a4324e"),//admin321
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Moderatör Kullanıcısı",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
                },
                new User
                {
                    Id = 3,
                    RoleId = 3,
                    FirstName = "Açelya",
                    LastName = "Yüce Memili",
                    UserName = "aym",
                    Email = "aym@outlook.com",
                    Descreption = "Bu Programın Yazarının Arkadaşının Eşi",
                    PasswordHash = Encoding.ASCII.GetBytes("e519e704c23eaf08787fb8f93c6bed32"),//admine123
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Normal Üye Kullanıcısı",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
                },
                new User
                {
                    Id = 4,
                    RoleId = 1,
                    FirstName = "Muhammet Fettah",
                    LastName = "Gön",
                    UserName = "mfg",
                    Email = "mfg@outlook.com",
                    Descreption = "Bu Programın Yazarının Oğlu",
                    PasswordHash = Encoding.ASCII.GetBytes("4818f12bac144583063649ad49ded466"),//mfg123
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Babadan Torpilli Admin",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
                });



        }
    }
}
