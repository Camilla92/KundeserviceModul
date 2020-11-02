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

        public async Task<bool> Lagre(SporsmalSvar innSporsmal)
        {

    
            var nySporsmalRad = new SporsmalSvar();
            nySporsmalRad.Sporsmalet = innSporsmal.Sporsmalet;
            _db.SporsmalSvar.Add(nySporsmalRad);
            await _db.SaveChangesAsync();
            return true;

            
        }

        public async Task<List<SporsmalSvar>> HentAlle()
        {
            
            List<SporsmalSvar> alleSvar = await _db.SporsmalSvar.ToListAsync();
           
            return alleSvar;
            

            

        }





    }
}
