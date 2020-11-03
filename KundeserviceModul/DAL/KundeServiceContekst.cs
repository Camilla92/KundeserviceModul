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
                // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
                // dette er uavhenig av initiering av databasen (seeding)
                // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
                Database.EnsureCreated();
            }

        public virtual DbSet<VurderingSporsmal> VurderingSporsmal { get; set; }
        public virtual DbSet<SporsmalSvar> SporsmalSvar { get; set; }
        public virtual DbSet<InnsendteSporsmal> InnsendteSporsmal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
