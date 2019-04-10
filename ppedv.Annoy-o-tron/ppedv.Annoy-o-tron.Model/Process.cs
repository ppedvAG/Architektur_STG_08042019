using System;
using System.Collections.Generic;

namespace ppedv.Annoy_o_tron.Model
{
    public class Process : Entity
    {
        public string Description { get; set; }
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }

        public virtual Template Template { get; set; }
        public virtual Person Tasker { get; set; }
        public virtual ICollection<Person> Assignees { get; set; } = new HashSet<Person>();
        public virtual ICollection<WorkItem> WorkItems { get; set; } = new HashSet<WorkItem>();
    }
}