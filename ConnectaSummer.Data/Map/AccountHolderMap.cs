using ConnectaSummer.Domain.AccountHolders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectaSummer.Data.Map
{
    public class AccountHolderMap : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar");
        }
    }
}