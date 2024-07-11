using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit6
{
    internal class Customer
    {
        static int numberOfItems;

        public Customer(int totalItems)
        {
            int ClothingItems = totalItems;

            if (ClothingItems == 0) 
            { 
                numberOfItems = DressingRoom.GetRandomNumber(1, 20); 
            }
            else
            {
                numberOfItems = ClothingItems;
            }
        }

        internal int GetNumberOfItems()
        {
            return numberOfItems;
        }
    }
}
