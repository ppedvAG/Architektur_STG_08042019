using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.Annoy_o_tron.Logic
{
    public class ProcessService
    {
        Core core;
        public ProcessService(Core core)
        {
            this.core = core;
        }

        public IEnumerable<Process> GetItemsOfTheDay(DateTime day)
        {
            //foreach (var item in UoW.ProcessRepository.Query().Where(x => x.Created <= day))
            foreach (var item in core.UoW.GetRepo<Process>().Query().Where(x => x.Created <= day))
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
    }
}
