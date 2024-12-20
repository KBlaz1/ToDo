using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class SortCreatedDatesDscCommand : ICommand
    {
        public Task[] Execute(Task[] tasks)
        {
            // insertion sort
            for (int i = 1; i < tasks.Length; i++)
            {
                Task key = tasks[i];
                int j = i - 1;

                while (j >= 0 && tasks[j].Timestamp < key.Timestamp)
                {
                    tasks[j + 1] = tasks[j];
                    j = j - 1;
                }
                tasks[j + 1] = key;
            }
            WriteTasksCommand writeTasksCommand = new WriteTasksCommand();
            writeTasksCommand.Execute(tasks);

            return tasks;
        }

    }
}