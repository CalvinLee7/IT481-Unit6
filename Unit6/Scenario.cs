using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit6
{
    internal class Scenario
    {
        public static Customer customer;
        public static int items = 0;
        public static int numberOfItems;
        public static int controlItemNumber;

        public Scenario(int room, int customer)
        {
            Console.WriteLine(room + " dressing rooms for " + customer + " customer.");
        }

    }
}
