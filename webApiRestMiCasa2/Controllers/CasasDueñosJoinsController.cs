using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiRestMiCasa2.Data;
using webApiRestMiCasa2.Models;

namespace webApiRestMiCasa2.Controllers
{
    public class CasasDueñosJoinsController : ApiController
    {
        // GET: api/CasasDueñosJoins
        public List<CasasDueñosJoins> Get()
        {
            return miCasasDueñosData.registrosInnerJoin();
        }

        // GET: api/CasasDueñosJoins/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CasasDueñosJoins
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CasasDueñosJoins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CasasDueñosJoins/5
        public void Delete(int id)
        {
        }
    }
}
