using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.model
{
    internal interface ICommand
    {
        public void Execute();
    }
}
