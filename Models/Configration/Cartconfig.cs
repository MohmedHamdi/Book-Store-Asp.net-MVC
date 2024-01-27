using bookstore1.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore1.Models.Configration
{
    public class Cartconfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.CartId);
            builder.HasOne(e => e.Book).WithMany(e => e.Carts).HasForeignKey(e => e.BookId);
        }
    }
}
