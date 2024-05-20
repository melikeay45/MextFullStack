using MextFullStack.Domain.Entities;
using MextFullStack.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStack.Persistance.Context
{



    public class ApplicationDbContext:DbContext
    {
        private readonly IRootPathService _rootPathService;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IRootPathService rootPathService) : base(options)
        {
            _rootPathService = rootPathService;
            var rootPath = _rootPathService.GetRootPath();
            _rootPathService.WriteTotalCount();
        }

        //Other use option
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("MextFullStackDB");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
