using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Data.Entities;

namespace Movies.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
              .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name).
                 HasMaxLength(150);

            builder
                .Property(x => x.Name).
                 IsRequired();

            builder
                .Property(x => x.Surname).
                 HasMaxLength(150);

            builder
                .Property(x => x.Surname).
                 IsRequired();

            builder
           .Property(x => x.Username).
            HasMaxLength(150);

            builder
           .Property(x => x.Email).
            HasMaxLength(150);

            builder.HasMany(x => x.MovieDetails).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        }
    }

}
