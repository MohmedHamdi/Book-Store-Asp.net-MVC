using bookstore1.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore1.Models.Configration
{
    public class CatogryConfig : IEntityTypeConfiguration<Catogry>
    {
        public void Configure(EntityTypeBuilder<Catogry> builder)
        {
            builder.HasKey(e => e.CatogryId);
            builder.Property(e => e.CatogryName).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            
        }
    }
}
