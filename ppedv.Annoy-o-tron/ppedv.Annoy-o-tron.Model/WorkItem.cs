using System;

namespace ppedv.Annoy_o_tron.Model
{
    public class WorkItem : Entity
    {
        public virtual Process Process { get; set; }
        public DateTime Time { get; set; }
        public WorkItemStatus Status { get; set; }
    }

    public enum WorkItemStatus
    {
        nö,
        läuft,
        kk
    }
}