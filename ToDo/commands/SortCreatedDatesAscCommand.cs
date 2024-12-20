using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class SortCreatedDatesAscCommand : ICommand
    {
        public model.Task[]? Execute(Task[] tasks)
        {
            // quick sort
            QuickSort(tasks, 0, tasks.Length - 1);

            WriteTasksCommand writeTasksCommand = new WriteTasksCommand();
            writeTasksCommand.Execute(tasks);

            return tasks;
        }

        private void QuickSort(Task[] tasks, int low, int high)
        {
            if (high > low)
            {
                int partition = Partition(tasks, low, high);

                QuickSort(tasks, low, partition - 1);
                QuickSort(tasks, partition + 1, high);
            }
        }

        private int Partition(Task[] tasks, int low, int high)
        {

            // choosing last element as pivot
            Task pivot = tasks[high];
            int i = low - 1;

            for (int j = low; j <= high -1; j++)
            {
                if (tasks[j].Timestamp < pivot.Timestamp)
                {
                    i++;
                    Swap(tasks, i, j);
                }
            }

            Swap(tasks, i + 1, high);
            return i + 1;
        }

        private void Swap(Task[] tasks, int i, int j)
        {
                    Task temp = tasks[i];
                    tasks[i] = tasks[j];
                    tasks[j] = temp;
        }
    }
}