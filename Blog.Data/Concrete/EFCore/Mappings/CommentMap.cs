using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Blog.Data.Concrete.EFCore.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(1000);
            builder.HasOne<Article>(c => c.Articles).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Comments");

            builder.HasData(
                new Comment
                {
                    Id = 1,
                    ArticleId = 1,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed urna enim, lacinia porttitor egestas et, interdum et risus. Integer tincidunt tempus rutrum. Duis tristique tortor tellus, quis rhoncus nulla sollicitudin at. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam in odio dictum, tempus eros sit amet, fringilla justo. Maecenas eu arcu tortor. Donec congue massa a placerat varius. Cras felis dolor, cursus et ullamcorper vitae, fermentum a nisl. Aliquam erat volutpat.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# Makale Yorumu",
                },
                new Comment
                {
                    Id = 2,
                    ArticleId = 2,
                    Text = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla aliquam leo nisl, ac tempus velit volutpat sed. Mauris mattis tellus non lobortis viverra. Etiam a efficitur nisl. Curabitur id accumsan sem. Suspendisse potenti. Nam luctus tempor nisi, quis elementum magna sodales sit amet. Curabitur vel rutrum urna. Mauris felis purus, tempor vitae congue vel, rutrum eu magna. Nullam pulvinar, arcu sit amet euismod tincidunt, leo lorem dictum turpis, eget tristique nunc dui vel sem.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Makale Yorumu",
                },
                new Comment
                {
                    Id = 3,
                    ArticleId = 3,
                    Text = "Nulla facilisi. Vestibulum eget porta lorem, ac placerat nibh. Nullam lectus massa, consequat et ligula eget, interdum hendrerit lectus. Sed varius tincidunt ligula, vel tempus lacus sollicitudin fringilla. Donec in commodo risus. Maecenas ornare eros vitae metus posuere congue. Pellentesque tincidunt vulputate malesuada.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Makale Yorumu",
                },
                new Comment
                {
                    Id = 4,
                    ArticleId = 4,
                    Text = "Vestibulum at porta orci. Aenean efficitur justo elit, ut dictum erat lobortis eu. Donec lacinia nibh turpis, sed blandit massa mattis vitae. Sed ex justo, pellentesque in tellus eget, rhoncus venenatis nibh. Cras feugiat nibh enim, et pulvinar quam feugiat et. Morbi ut tellus a mauris dapibus pharetra pharetra at metus. Aenean magna nisl, sodales sed dignissim in, dapibus eu mauris. In cursus magna vitae est accumsan pretium. Donec vitae dui nisi. Cras in risus nec turpis fringilla \"imperdiet\" vel et purus. Integer tristique vitae nunc laoreet porttitor. Sed arcu nisi, feugiat eget vulputate eget, tempus sed turpis. Sed ac ligula in odio pretium dignissim ut a ligula. Praesent mattis et neque at rhoncus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam non magna vestibulum, posuere ante eget, tempus odio.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Pyton Makale Yorumu",
                },
                new Comment
                {
                    Id = 5,
                    ArticleId = 5,
                    Text = "Donec ex erat, varius vitae arcu ac, euismod sagittis lectus. Fusce feugiat quam in dui malesuada, in tincidunt nunc tincidunt. Mauris ultrices ligula sit amet laoreet feugiat. Nulla laoreet rutrum libero, sit amet lobortis leo. Aenean posuere ipsum condimentum lacus faucibus, at tempor metus cursus. Aenean mauris nibh, volutpat id ultrices id, varius ut magna. Donec a ligula sed eros vestibulum porta sit amet et leo. Pellentesque eu orci lectus. Aenean semper vitae nisl quis semper. Suspendisse in nunc lacus. Vestibulum volutpat lectus tellus, sed sollicitudin felis elementum non. Aenean malesuada congue orci sed placerat. Nullam feugiat tellus sit amet tellus accumsan fermentum. Vestibulum euismod, nisl eu porttitor rhoncus, ligula metus hendrerit est, at blandit augue massa quis ante. Morbi ac mi at lectus fringilla bibendum.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Asp.net Makale Yorumu",
                }
                );
        }
    }
}
