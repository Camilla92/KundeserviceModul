using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KundeserviceModul.DAL
{
    public interface IKundeServiceRepository
    {

        Task<bool> Lagre(InnsendteSporsmal innSporsmal);
        //må gjøres om etterhvert som jeg vet hva som skal være i hentAlle
        Task<List<SporsmalSvar>> HentAlle();
        Task<bool> LagreVurdering(SporsmalSvar innID, int innVurderingLiker);
        
        
    }
}
