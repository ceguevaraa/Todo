using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Lists.Commands.UpdateItem
{
    public interface IUpdateItemCommand
    {
        void Execute(UpdateItemModel model);
    }
}
