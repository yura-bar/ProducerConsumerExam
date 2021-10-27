using ModelsDb;
using System;
using System.Collections.Generic;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Task> tasks = TasksGenerator.GenerateTasks();                
               
                foreach( var task in tasks)
                {
                    db.Tasks.Add(task);
                }
                db.SaveChanges();
                Console.WriteLine("Tasks created successfully");                
            }
            Console.Read();
        }
    }
}
