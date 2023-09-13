using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace DiscoveryZoneApi.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {



        }


        public DbSet<Category>? Categories { get; set; }
        public DbSet<Market>? Markets { get; set; }



        public DbSet<Offer>? Offers { get; set; }

        public DbSet<Field>? Fields { get; set; }


        public DbSet<Alert>? Alerts { get; set; }

        public DbSet<Card>? Cards { get; set; }



        public DbSet<Subscription>? Subscriptions { get; set; }



    }
}