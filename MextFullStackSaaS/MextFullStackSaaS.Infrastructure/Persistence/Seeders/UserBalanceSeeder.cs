using MextFullStackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullStackSaaS.Infrastructure.Persistence.Seeders
{
    public class UserBalanceSeeder : IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            var mextUserBalance = new UserBalance()
            {
                Id = new Guid(),
                UserId=new Guid(),
                Credits=20,
                CreatedOn = Convert.ToDateTime("2024-05-22T10:16:31+00:00"),
                CreatedByUserId="",
            };
            builder.HasData(mextUserBalance);
        }
    }
}
