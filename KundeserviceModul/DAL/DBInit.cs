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




                /*---------OPPRETTER SPØRSMÅL OG SVAR--------*/

                var svar1 = new SporsmalSvar { Sporsmalet = "Hei! Hvordan bestiller jeg meg en billett?", Svaret = "Du bestiller billett ved å gå til bestillsiden til Nor-Way bussekspress eller av våre bussjafører." , Liker = 1};
                var svar2 = new SporsmalSvar { Sporsmalet = "Hei! Hvordan bestiller jeg en billett til barnet mitt?", Svaret = "Du bestiller billett ved å gå til bestillside til Nor-Way bussekspress og velger antall barn, eller du kan kjøpe billett av våre bussjafører.", Liker = 10};
                var svar3 = new SporsmalSvar { Sporsmalet = "Hei! Hvordan bestiller jeg billetter til flere personer?", Svaret = "Du bestiller billett ved å gå til bestillsiden til Nor-Way bussekspress og velger antall voksne eller antall barn eller du kan kjøppe billetter av våre bussjafører.", Liker = 0};
                var svar4 = new SporsmalSvar { Sporsmalet = "Hei! Hvordan bestiller jeg billett til hunden min?", Svaret = "Billetter til hunder går som barnebillett på vår bestillingsside.", Liker = 0};
                var svar5 = new SporsmalSvar { Sporsmalet = "Hei! Hvordan kan jeg få rabatt?", Svaret = "Vi gir desverre ikke rabatt.", Liker = 0 , Misliker=1 };
                var svar6 = new SporsmalSvar { Sporsmalet = "Hei! Kan jeg ha med katten min på bussen?", Svaret = "Billetter til katter går som barnebillett på vår bestillingsside. Katten kan være med såfremt ingen er veldig allergiske på turen.", Liker = 0, Misliker=1 };
                var svar7 = new SporsmalSvar { Sporsmalet = "Hei! Hvor mange personer kan reise sammen?", Svaret = "Dere kan reise så mange personer dere vil, så fremt det er plss på turen.", Liker = 0 };
                var svar8 = new SporsmalSvar { Sporsmalet = "Hei! Barnet mitt har nøtteallergi, hvordan går jeg frem for å rapportere dette før reisen?", Svaret = "Send oss gjerne en mail til norway@info.no og eller si ifra til busssjåføren før avreise.", Liker = 0 };

                context.SporsmalSvar.Add(svar1);
                context.SporsmalSvar.Add(svar2);
                context.SporsmalSvar.Add(svar3);
                context.SporsmalSvar.Add(svar4);
                context.SporsmalSvar.Add(svar5);
                context.SporsmalSvar.Add(svar6);
                context.SporsmalSvar.Add(svar7);
                context.SporsmalSvar.Add(svar8);




                /*---------OPPRETTER InnsendteSpørsmål --------*/

                var innsendt1 = new InnsendteSporsmal { Epost = "sca@online.no", Sporsmalet = "hvordan ...." };
                var innsendt2 = new InnsendteSporsmal { Epost = "sca2@onlinetre.no", Sporsmalet = "hvordan ...." };
                var innsendt3 = new InnsendteSporsmal { Epost = "sca@online.nokko", Sporsmalet = "hvordan ...." };

                context.InnsendteSporsmal.Add(innsendt1);
                context.InnsendteSporsmal.Add(innsendt2);
                context.InnsendteSporsmal.Add(innsendt3);


                context.SaveChanges();

          
            }

        }
    }
}
