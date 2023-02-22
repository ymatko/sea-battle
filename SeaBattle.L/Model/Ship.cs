using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.L.Model
{
    public class Ship
    {
        public string Name { get; set; }
        public Point Coordinates { get; set; }
        public bool IsYourShip { get; set; }
        public bool IsSunken { get; set; }

        public Ship(string name, Point coordinates, bool isYourShip, bool isSunken)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username cannot be empty or null", "name");
            }
            Name = name;
            Coordinates = coordinates;  
            IsYourShip = isYourShip;
            IsSunken = isSunken;
        }
        public string GetShip()
        {
            return $"Name: {Name}\nCoordinates: {Coordinates.GetPoint()}" +
                $"\nIsYourShip: {IsYourShip}\nIsSunken: {IsSunken}";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
