using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundeserviceModul.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace KundeserviceModul.Controllers
{
    [ApiController]
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

        [HttpPost("lagre")]
        public async Task<ActionResult> Lagre(InnsendteSporsmal innSporsmal)
        {
            if (ModelState.IsValid)
            {

                bool returOk = await _db.Lagre(innSporsmal);
                if (!returOk)
                {
                    _log.LogInformation("Spørsmålet ble ikke registrert");
                    return BadRequest("Spørsmålet ble ikke registrert");
                }
                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");

        }


        [HttpPost("lagreVurderingLiker")]
        
        public async Task<ActionResult> LagreVurderingLiker([FromBody] int id)
        {
            if (ModelState.IsValid)
            {

                
                bool returOk = await _db.LagreVurderingLiker(id);
                if (!returOk)
                {
                    _log.LogInformation("Vurderingen ble ikke registrert");
                    return BadRequest("Vurderingen ble ikke registrert");
                }
                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();

        }


        [HttpPost("lagreVurderingMisliker")]
        
        public async Task<ActionResult> LagreVurderingMisliker([FromBody] int id)
        {
            if (ModelState.IsValid)
            {


                bool returOk = await _db.LagreVurderingMisliker(id);
                if (!returOk)
                {
                    _log.LogInformation("Vurderingen ble ikke registrert");
                    return BadRequest("Vurderingen ble ikke registrert");
                }
                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();

        }

    }
}

