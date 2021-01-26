using Microsoft.EntityFrameworkCore;
using TCG_Citadel.Data.MTG.Models;

namespace TCG_Citadel.Data.MTG
{
    public class MtgDbContext : DbContext
    {
        public DbSet<Card> MTG_Cards { get; set; }
        public DbSet<Rarity> MTG_Rarities { get; set; }
        public DbSet<Set> MTG_Sets { get; set; }
        public DbSet<SetType> MTG_SetTypes { get; set; }


        public MtgDbContext(DbContextOptions<MtgDbContext> options) : base(options)
        {

        }
    }
}
