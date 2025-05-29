using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Progressions.Commands.CreateProgression
{
    public class CreateProgressionModel
    {
        public DateTime CreatedAt { get; set; }
        public decimal Percentage { get; set; }
    }
}
