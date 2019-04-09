using System.Collections.Generic;

namespace ppedv.Annoy_o_tron.Model
{
    public abstract class Template : Entity
    {
        public ICollection<Process> Processes { get; set; } = new HashSet<Process>();
    }
}