using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Progressions;

namespace Todo.Application.Progressions.Factory
{
    public class ProgressionFactory : IProgressionFactory
    {
        public Progression Create( DateTime createdAt, decimal percentage)
        {
            return new Progression(createdAt, percentage)
            {
                Created = createdAt,
                Percentage = percentage
            };
        }
    }
}
