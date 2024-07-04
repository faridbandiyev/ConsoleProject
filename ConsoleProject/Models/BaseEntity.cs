using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public abstract class BaseEntity
    {
        protected static int _idCounter = 0;

        public int Id { get; protected set; }

        protected BaseEntity()
        {
            Id = ++_idCounter;
        }
    }
}
