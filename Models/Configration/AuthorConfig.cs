using bookstore1.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore1.Models.Configration
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.AuthorId);
            builder.Property(e=>e.FirstName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(e => e.LastName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
        }
    }
}
