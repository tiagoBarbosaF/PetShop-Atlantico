using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<PetOwner> PetOwner { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<Accommodation> Accommodation { get; set; }
    }
