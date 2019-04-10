using Ninject;
using ppedv.Annoy_o_tron.Logic;
using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Annoy_o_tron.UI.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Annoy-o-tron v0.1 PREMIUM ***");

            var ass = Assembly.LoadFile(@"C:\temp\Architektur_STG_08042019\ppedv.Annoy-o-tron\ppedv.Annoy_o_tron.Data.EF\bin\Debug\ppedv.Annoy_o_tron.Data.EF.dll"); 
            //var uowLLL = ass.GetTypes().FirstOrDefault(x => x.IsAssignableFrom(typeof(IUnitOfWork))); ///geht auch nciht ????? why???
            var uow = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IUnitOfWork)));

            //geht nicht ???? 
            //IKernel kernel = new StandardKernel();
            //kernel.Load("*.dll");
            //var uow = kernel.Get<IUnitOfWork>();
            //var core = new Core(uow);

            var core = new Core(Activator.CreateInstance(uow, "Server=.;Database=Annoy_dev;Trusted_Connection=true;") as IUnitOfWork);

            //core.DemoDatenService.CreateDemoData();

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
