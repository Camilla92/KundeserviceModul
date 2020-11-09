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

        public async Task<bool> LagreVurderingLiker(int id)
        {


           
           var endretRad= await _db.SporsmalSvar.FindAsync(id);
            if (endretRad == null) {
                return false;
            }
           
            //endretRad.Liker += innsendtVurdering.Liker;
            endretRad.Liker = endretRad.Liker + 1;

            //nyVurderingsRad= innsendtVurdering.Liker + nyVurderingsRad.Liker;

            //nyVurderingsRad.Liker = innsendtVurdering;

            //update SporsmalSvar set Liker =Liker + 1 where SvarId = @SvarId
            await _db.SaveChangesAsync();
            return true;


        }


        public async Task<bool> LagreVurderingMisliker(int id)
        {



            var endretRad = await _db.SporsmalSvar.FindAsync(id);
            if (endretRad == null)
            {
                return false;
            }

            //endretRad.Liker += innsendtVurdering.Liker;
            endretRad.Misliker = endretRad.Misliker + 1;

            //nyVurderingsRad= innsendtVurdering.Liker + nyVurderingsRad.Liker;

            //nyVurderingsRad.Liker = innsendtVurdering;

            //update SporsmalSvar set Liker =Liker + 1 where SvarId = @SvarId
            await _db.SaveChangesAsync();
            return true;


        }





    }
}
