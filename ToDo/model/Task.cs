using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DrawBoxes.DrawBoxes;

namespace ToDo.model
{
    public class Task
    {
        public String Title { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }

        public Task(String title, DateOnly date, TimeOnly time) {
            Title = title;
            Date = date;
            Time = time;
        }

        public override String ToString()
        {
            return DrawBox(Title, Date.ToString(), Time.ToString());
        }

        public static Task[] operator +(Task[] tasks, Task task)
        {
            return tasks.Append(task).ToArray();
        }
    }
}
