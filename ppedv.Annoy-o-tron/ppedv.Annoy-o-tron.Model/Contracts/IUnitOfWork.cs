namespace ppedv.Annoy_o_tron.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepo<T>() where T : Entity;
        IProcessRepository ProcessRepository { get; }
        int SaveAll();
    }
}
