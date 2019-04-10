using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Annoy_o_tron.Logic
{
    public class Core
    {
        public IUnitOfWork UoW { get; }

        public ProcessService ProcessService { get => new ProcessService(this); }
        public DemoDatenService DemoDatenService { get => new DemoDatenService(this); }

        public Core(IUnitOfWork uow)//todo Dependency Injection in here
        {
            UoW = uow;
        }

        //public Core() : this(new Data.EF.EfUnitOfWork())
        //{

        //}

    }
}
