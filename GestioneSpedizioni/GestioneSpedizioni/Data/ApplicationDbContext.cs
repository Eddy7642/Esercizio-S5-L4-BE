using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestioneSpedizioni.Models; // Assicurati di utilizzare il namespace corretto per i tuoi modelli

namespace GestioneSpedizioni.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Spedizione> Spedizioni { get; set; }
        public DbSet<AggiornamentoSpedizione> AggiornamentiSpedizione { get; set; }
    }
}
