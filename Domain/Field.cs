using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Field
    {
        public Point MinBoundary { get; private set; }
        public Point MaxBoundary { get; set; }
        public List<Car> Cars { get; private set; }

        public Field()
        {
            Cars = new List<Car>();
            MinBoundary = new Point(0, 0);
        }
    }
}
