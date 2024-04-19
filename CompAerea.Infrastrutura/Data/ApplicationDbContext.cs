using CompAerea.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CompAerea.Infrastrutura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
            
        }

        public DbSet<Avioes> Avioes { get; set; }
    }
}