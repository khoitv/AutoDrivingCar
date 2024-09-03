using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
{
    public static class CarExtensions
    {
        public static string Result(this Car car)
        {
            if (car.Collide != null)
                return $"{car.Name}, collides with {car.Collide.By.Name} at {car.Position.ToString()} at step {car.Collide.Step}";

            return $"{car.Name}, ({car.Position.X},{car.Position.Y}) {car.Direction}";
        }

        public static string Display(this Car car) => $"{car.Name.ToString()}, {car.Commands}";
    }
}
