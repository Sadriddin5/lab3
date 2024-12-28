using Microsoft.EntityFrameworkCore;

namespace SysProgLab3.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<AccountingGoods> AccountingGoods => Set<AccountingGoods>();
        public DbSet<PriceCurant> PriceCurants=> Set<PriceCurant>();
        public DbSet<MyUser> MyUsers => Set<MyUser>();
    }
}
