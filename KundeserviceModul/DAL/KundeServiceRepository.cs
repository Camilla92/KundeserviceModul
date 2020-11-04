using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KundeserviceModul.DAL
{
    public class KundeServiceReposity : IKundeServiceRepository
    {

        private readonly KundeServiceContekst _db;

        public KundeServiceReposity(KundeServiceContekst db)
        {
            _db = db;
        }
        public KundeServiceReposity()
        {
        }

        public async Task<bool> Lagre(InnsendteSporsmal innSporsmal)
        {

    
            var nySporsmalRad = new InnsendteSporsmal();
            
            nySporsmalRad.Sporsmalet = innSporsmal.Sporsmalet;
            nySporsmalRad.Epost = innSporsmal.Epost;
            _db.InnsendteSporsmal.Add(nySporsmalRad);
            await _db.SaveChangesAsync();
            return true;

            
        }

        public async Task<List<SporsmalSvar>> HentAlle()
        {
            
            List<SporsmalSvar> alleSvar = await _db.SporsmalSvar.ToListAsync();
           
            return alleSvar;
            

            

        }

        public async Task<bool> LagreVurdering(SporsmalSvar innID, int innVurderLiker, int innVurderMisliker)
        {


            var nyVurderingsRad = new SporsmalSvar();

            
            nyVurderingsRad.Liker = innVurderLiker++;
            nyVurderingsRad.Misliker = innVurderMisliker++;
            _db.SporsmalSvar.Add(nyVurderingsRad);
            await _db.SaveChangesAsync();
            return true;


        }





    }
}
