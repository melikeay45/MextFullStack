using MextFullStackSaaS.Domain.Entities;
using MextFullStackSaaS.Domain.Identity;
using MextFullStactSaaS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MextFullStackSaaS.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>, IApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }
        public DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }

    }
}
