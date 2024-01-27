using bookstore1.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace bookstore1.Models.Configration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);
            builder.Property(e=>e.Title).HasColumnType("varchar").HasMaxLength(25).IsRequired();
           // builder.HasMany(e => e.Author).WithMany(e => e.Books).UsingEntity(e => e.ToTable("BookAuthor"));
           builder.HasOne(e=>e.Author).WithMany(e=>e.Books).HasForeignKey(e=>e.AuthorId);
            builder.HasOne(e => e.Catogry).WithMany(e => e.Books).HasForeignKey(e => e.CatogryId) ;

            //  builder.Hasm(e => e.Order).WithMany(e => e.Books).HasForeignKey(e => e.OrderId);

       
        }
    }
}
