using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KundeserviceModul.DAL
{
    public interface IKundeServiceRepository
    {

        Task<bool> Lagre(InnsendteSporsmal innSporsmal, InnsendteSporsmal innEpost);
        //må gjøres om etterhvert som jeg vet hva som skal være i hentAlle
        Task<List<SporsmalSvar>> HentAlle();
        Task<bool> LagreVurdering(VurderingSporsmal innID, int innVurderingLiker, int innVurderingMisliker);
        
        
    }
}
