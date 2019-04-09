using System.Collections.Generic;

namespace ppedv.Annoy_o_tron.Model
{
    public class Person : Entity
    {
        public string Name { get; set; }
        /// <Remarks>
        /// Dinge! und Zeug
        /// virtual == LazyLoading in EntityFramework
        /// ICollection, weil niedrig nötiger Datentyp
        /// HashSet, keine Duplikate 
        /// </Remarks>
        public virtual ICollection<Process> ProcessesAsTasker { get; set; } = new HashSet<Process>();
        public virtual ICollection<Process> ProcessesAsAssignee { get; set; } = new HashSet<Process>();

    }
}