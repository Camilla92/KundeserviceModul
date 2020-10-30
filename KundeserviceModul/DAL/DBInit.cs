using System;
using KundeserviceModul.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KundeserviceModul.DAL
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                
                var context = serviceScope.ServiceProvider.GetService<KundeServiceContekst>();

                // må slette og opprette databasen hver gang når den skalinitieres (seed`es)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                /*---------OPPRETTER SPØRSMÅL--------*/

                var sporsmal1 = new Sporsmal { Sporsmalet = "Hei!, hvordan bestiller jeg meg en billett?" };
                var sporsmal2 = new Sporsmal { Sporsmalet = "Hei!, hvordan bestiller jeg en billett til barnet mitt?" };
                var sporsmal3 = new Sporsmal { Sporsmalet = "Hei!, hvordan bestiller jeg billetter til flere personer?" };
                var sporsmal4 = new Sporsmal { Sporsmalet = "Hei!, hvordan bestiller jeg billett til hunden min?" };

                context.Sporsmal.Add(sporsmal1);
                context.Sporsmal.Add(sporsmal2);
                context.Sporsmal.Add(sporsmal3);
                context.Sporsmal.Add(sporsmal4);


                /*---------OPPRETTER SVAR--------*/

                var svar1 = new Svar { Sporsmalet = sporsmal1, Svaret = "Du bestiller billett ved å gå til bestillsiden til Nor-Way bussekspress eller av våre bussjafører." };
                var svar2 = new Svar { Sporsmalet = sporsmal2, Svaret = "Du bestiller billett ved å gå til bestillside til Nor-Way bussekspress og velger antall barn, eller du kan kjøpe billett av våre bussjafører." };
                var svar3 = new Svar { Sporsmalet = sporsmal3, Svaret = "Du bestiller billett ved å gå til bestillsiden til Nor-Way bussekspress og velger antall voksne eller antall barn eller du kan kjøppe billetter av våre bussjafører." };
                var svar4 = new Svar { Sporsmalet = sporsmal4, Svaret = "Billetter til hunder går som barnebillett på vår bestillingsside." };


                context.Svar.Add(svar1);
                context.Svar.Add(svar2);
                context.Svar.Add(svar3);
                context.Svar.Add(svar4);

                context.SaveChanges();

          
            }

        }
    }
}
