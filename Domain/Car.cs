using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Car
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public char Direction { get; set; }
        public string Commands { get; set; }
        public int Degree { get; set; }
        public Collide Collide { get; set; }
    }
}
