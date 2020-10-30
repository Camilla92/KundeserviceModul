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

        public async Task<bool> Lagre(Sporsmal innSporsmal)
        {

    
            var nySporsmalRad = new Sporsmal();
            nySporsmalRad.Sporsmalet = innSporsmal.Sporsmalet;
            _db.Sporsmal.Add(nySporsmalRad);
            await _db.SaveChangesAsync();
            return true;

            
        }

        public async Task<List<Svar>> HentAlle()
        {

            List<Svar> alleSvar = await _db.Svar.ToListAsync();
            return alleSvar;
           
        }

        
    }
}
