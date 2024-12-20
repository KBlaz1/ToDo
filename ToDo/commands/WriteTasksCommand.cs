using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class WriteTasksCommand : ICommand
    {
        public Task[]? Execute(Task[] tasks)
        {
            DateOnly newDate, oldDate = new DateOnly();
            for (int i = 0; i < tasks.Length; i++)
            {
                newDate = tasks[i].Date;
                if (newDate != oldDate)
                {
                    Console.WriteLine(newDate.ToString());
                }
                Console.WriteLine(tasks[i] + "\n");

                oldDate = newDate;
            }
            return null;
        }
    }
}