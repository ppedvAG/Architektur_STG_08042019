using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Annoy_o_tron.Data.EF
{
    public class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            con.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            con.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return con.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return con.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return con.Set<T>();
        }

        public int SaveAll()
        {
            return con.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
                con.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
