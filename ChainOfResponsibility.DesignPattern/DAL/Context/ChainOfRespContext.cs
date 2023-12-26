using ChainOfResponsibility.DesignPattern.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibility.DesignPattern.DAL.Context
{
    public class ChainOfRespContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-40G2DNI\\SQLEXPRESS;initial Catalog=ChainOfDb;integrated Security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
