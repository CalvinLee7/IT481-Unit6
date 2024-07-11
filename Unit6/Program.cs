using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unit6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many customer? ");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"There are {numberOfCustomers} total customers");

            Console.Write("number of item? (0 = random generate number of item for each customer) ");
            Scenario.controlItemNumber = Int32.Parse(Console.ReadLine());
            
            if (Scenario.controlItemNumber != 0)
            {
                Scenario.controlItemNumber = 0;

                for (int i = 1; i < numberOfCustomers + 1; i++)
                {
                    Console.Write($"enter item number of customer {i} ");
                    int numberOfItem = Int32.Parse(Console.ReadLine());

                    Scenario.controlItemNumber += numberOfItem;
                }

                Console.WriteLine($"Total items entered for alll customers = {Scenario.controlItemNumber}");
            }

            Console.Write("how many dressing room? ");
            int totalRooms = Int32.Parse(Console.ReadLine());

            Scenario scenario = new Scenario(totalRooms, numberOfCustomers);

            DressingRoom dressingRoom = new DressingRoom(totalRooms);

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numberOfCustomers; i++)
            {
                Customer customer = new Customer(Scenario.controlItemNumber);
                
                Scenario.numberOfItems = customer.GetNumberOfItems();

                if (Scenario.controlItemNumber == 0)
                {
                    Scenario.items += Scenario.numberOfItems;
                }
                else
                {
                    Scenario.items = Scenario.numberOfItems;
                }

                tasks.Add(Task.Factory.StartNew(async () => { await dressingRoom.RequestRoom(customer,i); }));
                Thread.Sleep(500);
            }

            if (Scenario.controlItemNumber == 0) {
                Console.WriteLine($"Random generated number of all customers is {Scenario.items}");
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Average run time in milliseconds {0}", dressingRoom.GetRunTime() / numberOfCustomers);
            Console.WriteLine("Average wait time in milliseconds {0}", dressingRoom.GetWaitTime() / numberOfCustomers);
            Console.WriteLine("Total customers is {0}", numberOfCustomers);
            int averageItemsPerCsutomer = Scenario.items / numberOfCustomers;

            Console.WriteLine("Average number of items was: " + averageItemsPerCsutomer);
            Console.Read();
        }
    }
}
