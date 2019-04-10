using ppedv.Annoy_o_tron.Logic;
using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.Annoy_o_tron.UI.Web.Controllers
{
    public class ProcessAPIController : ApiController
    {
        Core core = new Core();
        // GET: api/ProcessAPI
        public IEnumerable<Process> Get()
        {
            return core.UoW.ProcessRepository.GetAll();
        }

        // GET: api/ProcessAPI/5
        public Process Get(int id)
        {
            return core.UoW.ProcessRepository.GetById(id);
        }

        // POST: api/ProcessAPI
        public void Post([FromBody]Process value)
        {
            core.UoW.ProcessRepository.Add(value);
            core.UoW.SaveAll();
        }

        // PUT: api/ProcessAPI/5
        public void Put(int id, [FromBody]Process value)
        {
            core.UoW.ProcessRepository.Update(value);
            core.UoW.SaveAll();
        }

        // DELETE: api/ProcessAPI/5
        public void Delete(int id)
        {
            var loaded = core.UoW.ProcessRepository.GetById(id);
            if (loaded != null)
            {
                core.UoW.ProcessRepository.Delete(loaded);
                core.UoW.SaveAll();
            }
        }
    }
}
