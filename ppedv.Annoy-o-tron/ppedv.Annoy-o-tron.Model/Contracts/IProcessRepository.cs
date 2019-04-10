namespace ppedv.Annoy_o_tron.Model.Contracts
{
    public interface IProcessRepository : IRepository<Process>
    {
        Process GetNextProcess();
    }
}
