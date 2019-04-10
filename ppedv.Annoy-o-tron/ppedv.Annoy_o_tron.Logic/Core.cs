using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Annoy_o_tron.Logic
{
    public class Core
    {
        public IUnitOfWork UoW { get; }

        public Core(IUnitOfWork uow)//todo Dependency Injection in here
        {
            UoW = uow;
        }

        public Core() : this(new Data.EF.EfUnitOfWork())
        {

        }

        public IEnumerable<Process> GetItemsOfTheDay(DateTime day)
        {
            //foreach (var item in UoW.ProcessRepository.Query().Where(x => x.Created <= day))
            foreach (var item in UoW.GetRepo<Process>().Query().Where(x => x.Created <= day))
            {
                if (item.Template is Daily d)
                {
                    if (d.OnlyWorkdays && day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                        yield return item;
                    else if (!d.OnlyWorkdays && (day - item.Created).TotalDays % d.DayInterval == 0)
                        yield return item;
                }
                if (item.Template is Weekly w)
                {
                    //todo...modulo 7 mal intervall
                }
            }
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

            UoW.GetRepo<Process>().Add(pro1);

            UoW.SaveAll();
        }
    }
}
