using Microsoft.EntityFrameworkCore;
using ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TasksStatistic
    {
       public void GetLatestTasks(List<int> consumerIDs)
       {
            using(ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.Where(t => t.Status == StatusEnum.Done.ToString());
                Console.WriteLine("Latest tasks List");
                Console.WriteLine();
                foreach (var consumerID in consumerIDs)
                {
                    var task = tasks.Where(t => t.ConsumerID == consumerID)
                        .OrderByDescending(t => t.ModificationTime).FirstOrDefault();
                   if(task != null)
                   {
                        var modificationTime = task.ModificationTime.Value.ToString("G");
                        Console.WriteLine($"Consumer {consumerID} finished his last task at {modificationTime}");
                   }
                   else
                   {
                        Console.WriteLine($"Consumer {consumerID} didn't finish any task");
                   }
                }
            }
       }

        public async void GetTasksStatistic()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = await db.Tasks.ToListAsync();
                Console.WriteLine("Tasks statistic");
                Console.WriteLine();
                foreach (var status in Enum.GetNames(typeof(StatusEnum)).ToList())
                {
                    var count = tasks.Where(t => t.Status == status).Count();
                    Console.WriteLine($"{status} - {count}");
                }
                var successfullyExecutedTaskTime = tasks.Where(t => t.Status == StatusEnum.Done.ToString())
                    .Select(t => (t.ModificationTime - t.CreationTime).Value.TotalSeconds).Average();
                Console.WriteLine($"Average processing time of successfully executed tasks - {successfullyExecutedTaskTime} seconds");
                var errors = tasks.Where(t => t.Status == StatusEnum.Error.ToString()).Count();
                Console.WriteLine($"Percentage of errors - {(errors / tasks.Count()) * 100}%");
            }
        }

    }
}
