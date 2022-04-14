using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Data.Entities;

namespace Movies.Data.Configuration
{
    public class MovieDetailConfiguration : IEntityTypeConfiguration<MovieDetail>
    {
        public void Configure(EntityTypeBuilder<MovieDetail> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.UserId).
                 IsRequired();

            builder
                .Property(x => x.MovieId).
                 IsRequired();

            builder
                .Property(x => x.Comment).
                 HasMaxLength(250);

        }
    }
}
