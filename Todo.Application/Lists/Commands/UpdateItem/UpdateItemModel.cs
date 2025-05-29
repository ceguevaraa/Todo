using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Lists.Commands.UpdateItem
{
    public class UpdateItemModel
    {
        public int Id { get; set; }
        public string Description { get; set; }    
    }
}
