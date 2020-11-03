using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundeserviceModul.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KundeserviceModul.Controllers
{
    [Route("api/[controller]")]
    public class KundeServiceController : ControllerBase
    {
        
        private readonly ILogger<KundeServiceController> _log;
        private readonly IKundeServiceRepository _db;

        public KundeServiceController(IKundeServiceRepository db, ILogger<KundeServiceController> log)
        {
            _db = db;
            _log = log;
        }
        [HttpGet]
        public async Task<ActionResult> HentAlle()
        {
            List<SporsmalSvar> alleSvarene = await _db.HentAlle();
            return Ok(alleSvarene);
        }

        [HttpPost]
        public async Task<ActionResult> Lagre(InnsendteSporsmal innSporsmal, InnsendteSporsmal innEpost)
        {
            if (ModelState.IsValid)
            {

                bool returOk = await _db.Lagre(innSporsmal, innEpost);
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

        [HttpPost]
        public async Task<ActionResult> LagreVurdering(VurderingSporsmal innID, int innVurderingLiker, int innVurderingMisliker)
        {
            if (ModelState.IsValid)
            {

                bool returOk = await _db.LagreVurdering(innID, innVurderingLiker, innVurderingMisliker);
                if (!returOk)
                {
                    _log.LogInformation("Vurderingen ble ikke registrert");
                    return BadRequest("Vurderingen ble ikke registrert");
                }
                return Ok("Vurderingen er registrert");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");

        }

    }
}

