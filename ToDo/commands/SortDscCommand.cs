using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class SortDscCommand : ICommand
    {
        public Task[] Execute(Task[] tasks)
        {
            // selection sort
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                int max_idx = i;

                for (int j = i + 1; j < tasks.Length; j++)
                {
                    if (tasks[j].Date > tasks[max_idx].Date)
                        max_idx = j;
                }

                Task temp = tasks[i];
                tasks[i] = tasks[max_idx];
                tasks[max_idx] = temp;
            }
            WriteTasksCommand writeTasksCommand = new WriteTasksCommand();
            writeTasksCommand.Execute(tasks);
            return tasks;
        }
    }
}