using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;

namespace QWSC
{
    class Program
    {
        static void Main(string[] args)
        {
            CoupeManager manager = new CoupeManager();
            List<Coupe> list =  manager.GetListCoupes();
            Console.Out.WriteLine("---------------------Qwidich World Championship Manager---------------------");
            Console.Out.WriteLine("----------------------------------------------------------------------------");
            Console.Out.WriteLine("Liste des coupes :");
            foreach(Coupe current in list)
            {
                Console.Out.WriteLine("Cup " + current.Year);
            }
            Console.Out.WriteLine("----------------------------------------------------------------------------");
            if(list.Count > 0)
            {
                Coupe cup = list.ElementAt(0);
                Console.Out.WriteLine("Liste des attrapeur à domicile :");
                foreach (String current in manager.GetListDomicileAttrapeur(cup))
                {
                    Console.Out.WriteLine(current);
                }
                Console.Out.WriteLine("----------------------------------------------------------------------------");
                Console.Out.WriteLine("Liste des stades :");
                foreach (String current in manager.GetListStadeWithMatch(cup))
                {
                    Console.Out.WriteLine(current);
                }
                Console.Out.WriteLine("----------------------------------------------------------------------------");
                Console.Out.WriteLine("Liste des match :");
                foreach (String current in manager.GetMatchClasse(cup))
                {
                    Console.Out.WriteLine(current);
                }
                Console.Out.WriteLine("----------------------------------------------------------------------------");
            }
            Console.In.ReadLine();

        }
    }
}
