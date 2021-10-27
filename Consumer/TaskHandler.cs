using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using ModelsDb;

namespace Consumer
{
    internal class TaskHandler
    {
        private readonly int consumerId;
        private readonly int bulkSize;

        internal TaskHandler(int _consumerId, int _bulkSize)
        {
            consumerId = _consumerId;
            bulkSize = _bulkSize;
        }


        internal async void HandleTasks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.Where(t => t.ConsumerID == consumerId && t.Status == StatusEnum.Pending.ToString())
                    .Take(bulkSize).ToList();

                if (tasks !=null && tasks.Any())
                {
                    foreach (var task in tasks)
                    {
                        try
                        {
                            task.Status = StatusEnum.InProgress.ToString();
                            task.ModificationTime = DateTime.UtcNow;
                            db.Tasks.Update(task);
                            await db.SaveChangesAsync();                            
                            Console.WriteLine($"Consumer {consumerId} prints : {task.TaskText}");
                            task.Status = StatusEnum.Done.ToString();
                            task.ModificationTime = DateTime.UtcNow;
                            db.Tasks.Update(task);                           
                        }
                        catch
                        {
                            task.Status = StatusEnum.Error.ToString();
                            task.ModificationTime = DateTime.UtcNow;
                            db.Tasks.Update(task);                            
                        }
                    }                    
                    await db.SaveChangesAsync();
                    HandleTasks();
                }
                else
                {                    
                    Thread.Sleep(100000);
                    HandleTasks();
                }

            }
        }
    }
}
