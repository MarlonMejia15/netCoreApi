using Microsoft.EntityFrameworkCore;
using ProyectoApi.Models;

namespace ProyectoApi.Data
{
    public class ContactoAPIDbContext : DbContext
    {
        public ContactoAPIDbContext(DbContextOptions options) : base(options) {
            

        }

        public DbSet<Contacto> Contactos { get; set; }
        
    }
}
