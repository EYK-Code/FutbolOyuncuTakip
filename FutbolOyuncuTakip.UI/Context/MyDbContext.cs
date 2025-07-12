using FutbolOyuncuTakip.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace FutbolOyuncuTakip.UI.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Lig> Lig { get; set; }
        public DbSet<Takim> Takim { get; set; }
        public DbSet<Futbolcu> Futbolcu { get; set; }
    }
}
