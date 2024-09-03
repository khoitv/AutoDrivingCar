using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarRepository
    {
        bool InitPosition(Car car, string text);
        void Move(Car car, int step, Point minBoundary, Point maxBoundary);
        void UpdateCollidate(Car car, Car collidateBy, Point position, int step);
    }
}
