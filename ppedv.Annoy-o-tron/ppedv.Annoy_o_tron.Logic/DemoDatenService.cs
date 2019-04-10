using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Annoy_o_tron.Logic
{
    public class DemoDatenService
    {
        Core core;
        public DemoDatenService(Core core)
        {
            this.core = core;
        }
        public void CreateDemoData()
        {
            var p1 = new Person() { Name = "Fred" };
            var p2 = new Person() { Name = "Wilma" };
            var p3 = new Person() { Name = "Barney" };
            var p4 = new Person() { Name = "Betty" };

            var pro1 = new Process()
            {
                Description = "Jagen",
                Tasker = p2,
                Begin = new TimeSpan(10, 0, 0),
                End = new TimeSpan(12, 0, 0)
            };
            pro1.Assignees.Add(p1);
            pro1.Assignees.Add(p3);

            pro1.WorkItems.Add(new WorkItem() { Time = new DateTime(2019, 4, 7), Status = WorkItemStatus.kk });
            pro1.WorkItems.Add(new WorkItem() { Time = new DateTime(2019, 4, 8), Status = WorkItemStatus.nö });
            pro1.WorkItems.Add(new WorkItem() { Time = new DateTime(2019, 4, 9), Status = WorkItemStatus.läuft });

            pro1.Template = new Daily() { OnlyWorkdays = true };

            core.UoW.GetRepo<Process>().Add(pro1);

            core.UoW.SaveAll();
        }
    }
}
