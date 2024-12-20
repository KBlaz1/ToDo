using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using static DrawBoxes.DrawBoxes;

namespace ToDo.model
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }

        [JsonIgnore]
        public DateOnly Date
        {
            get
            {
                return DateOnly.FromDateTime(DateTime);
            }
        }

        [JsonIgnore]
        public TimeOnly Time
        {
            get
            {
                return TimeOnly.FromDateTime(DateTime);
            }
        }

        public DateTime DateTime { get; set; }

        public DateTime Timestamp { get; set; }

        [JsonConstructor]
        public Task(string title, DateTime dateTime, EntityId entityId, DateTime timestamp) : base(entityId)
        {
            Title = title;
            DateTime = dateTime;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return DrawBox(EntityId.Id + ". " + Title, Date.ToString(), Time.ToString(), "created: " + Timestamp.ToString());
        }

        public static Task[] operator +(Task[] tasks, Task task)
        {
            return tasks.Append(task).ToArray();
        }
    }
}
