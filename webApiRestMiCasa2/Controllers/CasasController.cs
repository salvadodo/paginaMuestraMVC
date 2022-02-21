﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiRestMiCasa2.Data;
using webApiRestMiCasa2.Models;

namespace webApiRestMiCasa2.Controllers
{
    public class CasasController : ApiController
    {
        // GET: api/Casas
        public List<Casas> Get()
        {
            return miCasaData.registrosCasas();
        }

        // GET: api/Casas/5
        public Casas Get(int id)
        {
            return miCasaData.selectCasa(id);
        }

        // POST: api/Casas
        public bool Post([FromBody]Casas insCasa)
        {
            return miCasaData.insertarCasa(insCasa);
        }

        // PUT: api/Casas/5
        public bool Put([FromBody]Casas modCasa)
        {
            return miCasaData.modificarCasas(modCasa);
        }

        // DELETE: api/Casas/5
        public bool Delete(int eliCasa)
        {
            return miCasaData.eliminarCasa(eliCasa);
        }
    }
}
