using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundeserviceModul.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KundeserviceModul.Controllers
{
    public class KundeServiceController : ControllerBase
    {
        
        private readonly ILogger<KundeServiceController> _log;
        private readonly IKundeServiceRepository _db;

        public KundeServiceController(IKundeServiceRepository db, ILogger<KundeServiceController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> HentAlle()
        {
            List<Svar> alleSvarene = await _db.HentAlle();
            return Ok(alleSvarene);
        }
        public async Task<ActionResult> Lagre(Sporsmal innSporsmal)
        {
            if (ModelState.IsValid)
            {

                bool returOk = await _db.Lagre(innSporsmal);
                if (!returOk)
                {
                    _log.LogInformation("Spørsmålet ble ikke registrert");
                    return BadRequest("Spørsmålet ble ikke registrert");
                }
                return Ok("Spørsmålet er registrert");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");

        }

    }
}

