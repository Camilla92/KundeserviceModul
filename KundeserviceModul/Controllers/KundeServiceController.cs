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


        /*
          try
            {
                 try
            {
                var qa = _databaseContext.QandAs.FirstOrDefault(q => q.Id == id);
                if (qa != null) qa.UpVotes += 1;
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
                if (qa != null) qa.UpVotes += 1;
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }*/

        [HttpPost("lagreVurdering")]
        //[FromBody] int innId
        public async Task<ActionResult> LagreVurdering(SporsmalSvar innSporsmalSvar)
        {
            if (ModelState.IsValid)
            {

                
                bool returOk = await _db.LagreVurdering(innSporsmalSvar);
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

