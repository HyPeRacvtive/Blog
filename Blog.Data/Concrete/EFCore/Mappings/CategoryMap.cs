using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Blog.Data.Concrete.EFCore.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "C#",
                Description = "C# Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "C# Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,

            },
            new Category
            {
                Id = 2,
                Name = "C++",
                Description = "C++ Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "C++ Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
            },
            new Category
            {
                Id = 3,
                Name = "JavaScript",
                Description = "JavaScript Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "JavaScript Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
            },
            new Category
            {
                Id = 4,
                Name = "Pyton",
                Description = "Pyton Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "Pyton Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
            },
            new Category
            {
                Id = 5,
                Name = "Kotlin",
                Description = "Kotlin Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "Kotlin Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
            },
            new Category
            {
                Id = 6,
                Name = "Asp.Net",
                Description = "Asp.Net Programlama Dili İLe İlgili En Güncel Bilgiler",
                Note = "Asp.Net Blog Kategorisi",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
            }
            );

        }
    }
}
