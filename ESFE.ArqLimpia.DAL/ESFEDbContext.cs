using ESFE.ArqLimpia.EN;
using Microsoft.EntityFrameworkCore;

namespace ESFE.ArqLimpia.DAL
{
    public class ESFEDbContext:DbContext
    {
        public ESFEDbContext(DbContextOptions<ESFEDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}