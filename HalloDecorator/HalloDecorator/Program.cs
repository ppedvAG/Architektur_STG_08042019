using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Deco");

            var lecker1 = new Käse(new Käse(new Salami(new Käse(new Pizza()))));

            Console.WriteLine($"Lecker 1: {lecker1.Name} {lecker1.Preis}");

            Console.ReadKey();
        }
    }
    public interface ICompo
    {
        string Name { get; }
        decimal Preis { get; }
    }

    public class Pizza : ICompo
    {
        public string Name => "Pizza";

        public decimal Preis => 6.2m;
    }

    public class Brot : ICompo
    {
        public string Name => "Brot";

        public decimal Preis => 2.8m;
    }


    public abstract class Deco : ICompo
    {
        public abstract string Name { get; }
        public abstract decimal Preis { get; }

        protected ICompo parent;
        public Deco(ICompo parent)
        {
            this.parent = parent;
        }
    }


    public class Käse : Deco
    {
        public Käse(ICompo parent) : base(parent)
        { }

        public override string Name => $"{parent.Name} Käse";

        public override decimal Preis => parent.Preis + 1.5m;
    }

    public class Salami : Deco
    {
        public Salami(ICompo parent) : base(parent)
        { }

        public override string Name => $"{parent.Name} Salami";

        public override decimal Preis => parent.Preis + 2.7m;
    }
}
