using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCG_Citadel.Data.UserCollection.Models;

namespace TCG_Citadel.Data.UserCollection
{
    public class UserCollectionDbContext : DbContext
    {
        public DbSet<CollectionCard> UserCollectedCards { get; set; }
        public UserCollectionDbContext(DbContextOptions<UserCollectionDbContext> options) : base(options)
        {

        }
    }
}
