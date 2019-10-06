using Filed.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filed.API.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<PaymentStateEntitiy> PaymentStates { get; set; }
    }
}
