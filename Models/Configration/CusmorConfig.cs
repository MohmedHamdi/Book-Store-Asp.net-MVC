using bookstore1.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore1.Models.Configration
{
    public class CusmorConfig : IEntityTypeConfiguration<Custmors>
    {
        public void Configure(EntityTypeBuilder<Custmors> builder)
        {
            builder.HasKey(b => b.CustmorsId);

        }
    }
}
