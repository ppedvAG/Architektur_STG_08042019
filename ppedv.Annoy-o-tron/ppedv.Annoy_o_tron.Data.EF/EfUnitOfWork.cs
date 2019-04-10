using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;

namespace ppedv.Annoy_o_tron.Data.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public IProcessRepository ProcessRepository => new EfProcessRepository(con);

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(con);
        }

        public int SaveAll()
        {
            return con.SaveChanges();
        }

        EfContext con = null;

        public EfUnitOfWork(string conString)
        {
            con = new EfContext(conString);
        }
    }
}
