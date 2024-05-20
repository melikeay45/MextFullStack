using MextFullStackSaaS.Domain.Entities;
using MextFullStackSaaS.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MextFullStactSaaS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<UserBalance> UserBalances { get; set; }
        DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
