using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Lists.Commands.UpdateItem;

namespace Todo.Application.Lists.Commands.DeleteItem
{
    public interface IDeleteItemCommand
    {
        void Execute(int id);
    }
}
