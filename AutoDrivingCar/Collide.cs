using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCar
{
    public class Collide
    {
        public Collide(Car by, Point position, int step)
        {
            By = by;
            Position = position;
            Step = step;
        }

        public Car By { get; set; }
        public Point Position { get; set; }
        public int Step { get; set; }

    }
}
