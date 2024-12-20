using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public interface ICommand
    {
        public Task[]? Execute(Task[]? tasks = null);
    }
}
