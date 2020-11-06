using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KundeserviceModul.DAL
{
    public interface IKundeServiceRepository
    {

        Task<bool> Lagre(InnsendteSporsmal innSporsmal);
        Task<List<SporsmalSvar>> HentAlle();
        Task<bool> LagreVurdering(SporsmalSvar innsendtVurdering);
        
        
    }
}
