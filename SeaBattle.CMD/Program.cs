using SeaBattle.L.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(4, 5);
            Ship ship = new Ship("A1", point, true, false);
            Console.WriteLine(ship.GetShip());
            Console.ReadLine();
        }
    }
}
