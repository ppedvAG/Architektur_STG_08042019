using AutoMapper;
using ppedv.Annoy_o_tron.Logic;
using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.ApiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.Annoy_o_tron.UI.Web.Controllers
{
    public class ProcessDTOAPIController : ApiController
    {
        Core core = new Core();
        static ProcessDTOAPIController()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Process, ProcessDTO>().ReverseMap();
            });

        }

        // GET: api/ProcessAPI
        public IEnumerable<ProcessDTO> Get()
        {
            //return core.UoW.ProcessRepository.GetAll();
            //foreach (var p in core.UoW.ProcessRepository.GetAll())
            //{
            //    yield return new ProcessDTO() { Id = p.Id, Begin = p.Begin, End = p.End };
            //}

            foreach (var p in core.UoW.ProcessRepository.GetAll())
            {
                yield return Mapper.Map<ProcessDTO>(p);
            }

        }

        // GET: api/ProcessAPI/5
        public ProcessDTO Get(int id)
        {
            return Mapper.Map<ProcessDTO>(core.UoW.ProcessRepository.GetById(id));
        }

        // POST: api/ProcessAPI
        public void Post([FromBody]ProcessDTO value)
        {
            core.UoW.ProcessRepository.Add(Mapper.Map<Process>(value));
            core.UoW.SaveAll();
        }

        // PUT: api/ProcessAPI/5
        public void Put(int id, [FromBody]ProcessDTO value)
        {
            core.UoW.ProcessRepository.Update(Mapper.Map<Process>(value));
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
