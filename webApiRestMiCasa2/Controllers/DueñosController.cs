using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiRestMiCasa2.Data;
using webApiRestMiCasa2.Models;

namespace webApiRestMiCasa2.Controllers
{
    public class DueñosController : ApiController
    {
        // GET: api/Dueños
        [HttpGet]
        [Route("api/Dueños")]
        public List<Dueños> Get()
        {
            return miDueñosData.registrosDueños();
        }

        // GET: api/Dueños/5
        [HttpGet]
        [Route("api/Dueños/{idDueño}")]
        public Dueños Get(int idDueño)
        {
            return miDueñosData.selectDueño(idDueño);
        }

        // POST: api/Dueños
        [HttpPost]
        [Route("api/Dueños")]
        public bool Post([FromBody]Dueños insDueño)
        {
            return miDueñosData.insertarDueño(insDueño);
        }

        // PUT: api/Dueños/5
        [HttpPut]
        [Route("api/Dueños/{modDueño}")]
        public bool Put([FromBody]Dueños modDueño)
        {
            return miDueñosData.modificarDueño(modDueño);
        }

        // DELETE: api/Dueños/5
        [HttpDelete]
        [Route("api/Dueños/{eliDueño}")]
        public bool Delete(int eliDueño)
        {
            return miDueñosData.eliminarDueño(eliDueño);
        }
    }
}
