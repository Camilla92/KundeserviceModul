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

        public async Task<bool> Lagre(InnsendteSporsmal innSporsmal, InnsendteSporsmal innEpost)
        {

    
            var nySporsmalRad = new InnsendteSporsmal();
            
            nySporsmalRad.Sporsmalet = innSporsmal.Sporsmalet;
            nySporsmalRad.Epost = innEpost.Epost;
            _db.InnsendteSporsmal.Add(nySporsmalRad);
            await _db.SaveChangesAsync();
            return true;

            
        }

        public async Task<List<SporsmalSvar>> HentAlle()
        {
            
            List<SporsmalSvar> alleSvar = await _db.SporsmalSvar.ToListAsync();
           
            return alleSvar;
            

            

        }

        public async Task<bool> LagreVurdering(VurderingSporsmal innID, int innVurderLiker, int innVurderMisliker)
        {


            var nyVurderingsRad = new VurderingSporsmal();

            nyVurderingsRad.SvarId = innID.SvarId;
            nyVurderingsRad.Liker = innVurderLiker++;
            nyVurderingsRad.Misliker = innVurderMisliker++;
            _db.VurderingSporsmal.Add(nyVurderingsRad);
            await _db.SaveChangesAsync();
            return true;


        }





    }
}
