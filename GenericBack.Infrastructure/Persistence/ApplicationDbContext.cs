using GenericBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericBack.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
