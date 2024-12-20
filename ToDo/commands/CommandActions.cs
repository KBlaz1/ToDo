using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.commands
{
    public static class CommandActions
    {
        public static readonly string newTask = "new";
        public static readonly string deleteTask = "delete";
        public static readonly string sortTasksAsc = "sort asc";
        public static readonly string sortTasksDsc = "sort dsc";
        public static readonly string sortTasksByCreatedDateAsc = "sort created asc";
        public static readonly string sortTaskByCreatedDateDsc = "sort created dsc";
        public static readonly string writeTasks = "write";
        public static readonly string help = "help";
    }
}