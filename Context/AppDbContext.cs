using Microsoft.EntityFrameworkCore;
using NFeApi.Entities;

namespace NFeApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NFe> NFes { get; set; }
        public DbSet<Emitente> Emitentes { get; set; }
        public DbSet<ItemNFe> ItensNFe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NFe>()
                .HasOne(n => n.Emitente)
                .WithOne(e => e.NFe)
                .HasForeignKey<Emitente>(e => e.NFeId);

            modelBuilder.Entity<NFe>()
                .HasMany(n => n.ItensNFe)
                .WithOne(i => i.NFe)
                .HasForeignKey(i => i.NFeId);
        }
    }
}