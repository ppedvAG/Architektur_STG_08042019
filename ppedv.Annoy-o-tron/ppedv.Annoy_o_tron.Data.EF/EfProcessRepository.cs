using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;
using System;

namespace ppedv.Annoy_o_tron.Data.EF
{
    public class EfProcessRepository : EfRepository<Process>, IProcessRepository
    {
        public EfProcessRepository(EfContext con) : base(con)
        { }

        public Process GetNextProcess()
        {
            //todo call stored Procedure
            throw new NotImplementedException();
        }
    }
}
