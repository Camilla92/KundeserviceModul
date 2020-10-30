using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KundeserviceModul.DAL
{
    public interface IKundeServiceRepository
    {

        Task<bool> Lagre(Sporsmal innSporsmal);
        //må gjøres om etterhvert som jeg vet hva som skal være i hentAlle
        Task<List<Svar>> HentAlle();
       
    }
}
