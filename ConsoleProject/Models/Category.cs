﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
