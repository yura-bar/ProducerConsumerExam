using Repository;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Consumer
{
    internal class ConsumerCreator
    {
        
        internal void CreateConsumerAndHandleTasks(int consumersQuantity, int bulkSize)
        { 
            var consumerIDs = new List<int>();
            for (int i = 1; i <= consumersQuantity; i++)
            {
                var consumer = new Consumer { Id = i };
                consumerIDs.Add(i);
                var taskHandler = new TaskHandler(consumer.Id, bulkSize);
                Thread thread = new Thread(new ThreadStart(taskHandler.HandleTasks));
                thread.IsBackground = true;
                thread.Start();
            }

            while (!Console.KeyAvailable)
            {
                Thread.Sleep(10000);
                Console.WriteLine();
                var taskStatistic = new TasksStatistic();
                taskStatistic.GetLatestTasks(consumerIDs);
                Console.WriteLine();
                taskStatistic.GetTasksStatistic();                
            }

        }
    }
}
