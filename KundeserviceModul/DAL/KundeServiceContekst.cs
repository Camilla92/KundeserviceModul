using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KundeserviceModul.DAL
{
    public class KundeServiceContekst : DbContext
    {
        public KundeServiceContekst(DbContextOptions<KundeServiceContekst> options)
            : base(options)
        {
                Database.EnsureCreated();
            }

        
        public virtual DbSet<SporsmalSvar> SporsmalSvar { get; set; }
        public virtual DbSet<InnsendteSporsmal> InnsendteSporsmal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
