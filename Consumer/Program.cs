using Repository;
using System;
using System.Threading;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many consumers you want to create?");
            int consumersQuantity = int.Parse(Console.ReadLine());            
            Console.WriteLine("How many tasks consumer should take every time check for new tasks? ");
            int bulkSize = int.Parse(Console.ReadLine());
            var consumerCreator = new ConsumerCreator();
            consumerCreator.CreateConsumerAndHandleTasks(consumersQuantity, bulkSize);            

            Console.ReadLine();
        }
    }
}
