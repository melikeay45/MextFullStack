using MextFullStackSaaS.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullStackSaaS.Infrastructure.Persistence.Seeders
{
    public class UserSeeder:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User()
            {
                Id=new Guid(""),
                UserName="mextuser",
                NormalizedUserName="MEXTUSER",
                Email="mextUser@gmail.com",
                NormalizedEmail="MEXTUSER@GMAIL.COM",
                EmailConfirmed=true,
                FirstName="Mext",
                LastName="User",
                CreatedOn=Convert.ToDateTime("2024-05-22T10:16:31+00:00"),
                CreatedByUserId="",
                SecurityStamp= "6c185769-9f7b-47e8-a70c-dc7b892089de",
            };
            user.PasswordHash = CreatePasswordHash(user, "123mextuser123");
            builder.HasData(user);
        }

        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();

            return passwordHasher.HashPassword(user, password);
        }
    }
}
