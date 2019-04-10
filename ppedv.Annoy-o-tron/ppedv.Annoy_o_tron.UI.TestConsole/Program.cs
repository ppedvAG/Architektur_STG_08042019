using ppedv.Annoy_o_tron.Logic;
using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Annoy_o_tron.UI.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Annoy-o-tron v0.1 PREMIUM ***");

            var core = new Core();

            //core.CreateDemoData();

            foreach (var p in core.UoW.GetRepo<Process>().GetAll())
            {
                Console.WriteLine($"{p.Description} {p.Begin}-{p.End} by {p.Tasker?.Name} to: {string.Join(", ", p.Assignees.Select(x => x?.Name))}");
                p.WorkItems.ToList().ForEach(x => Console.WriteLine($"\t{x.Time:d} {x.Status}"));
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
