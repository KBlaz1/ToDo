using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class SortAscCommand : ICommand
    {
        public Task[] Execute(Task[] tasks)
        {
            // bubble sort
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < tasks.Length - i - 1; j++)
                {
                    if (tasks[j].Date > tasks[j + 1].Date)
                    {
                        Task temp = tasks[j + 1];
                        tasks[j + 1] = tasks[j];
                        tasks[j] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            WriteTasksCommand writeTasksCommand = new WriteTasksCommand();
            writeTasksCommand.Execute(tasks);

            return tasks;
        }
    }
}