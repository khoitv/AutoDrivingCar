using Application.Commons;
using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure
{
    public class CarRepository : ICarRepository
    {
        public bool InitPosition(Car car, string text)
        {
            try
            {
                int x = int.Parse(text.Split(" ")[0].Trim());
                int y = int.Parse(text.Split(" ")[1].Trim());
                char direction = char.Parse(text.Split(" ")[2].Trim());
                car.Position = new Point(x, y);
                car.Direction = direction;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Move(Car car, int step, Point minBoundary, Point maxBoundary)
        {
            if (step <= car.Commands.Length)
            {
                var command = car.Commands[step];
                if (command == 'F')
                {
                    MoveForward(car, minBoundary, maxBoundary);
                }
                if (command == 'R')
                {
                    TurnRight(car);
                }
                if (command == 'L')
                {
                    TurnLeft(car);
                }
            }
        }
        private void MoveForward(Car car, Point minBoundary, Point maxBoundary)
        {
            if (car.Direction == Constants.N)
            {
                if (car.Position.Y + Constants.F <= maxBoundary.Y)
                    car.Position.Y += Constants.F;
            }
            else if (car.Direction == Constants.S)
            {
                if (car.Position.Y - Constants.F >= minBoundary.Y)
                    car.Position.Y -= Constants.F;
            }
            else if (car.Direction == Constants.E)
            {
                if (car.Position.X + Constants.F <= maxBoundary.X)
                    car.Position.X += Constants.F;
            }
            else if (car.Direction == Constants.W)
            {
                if (car.Position.X - Constants.F >= minBoundary.X)
                    car.Position.X -= Constants.F;
            }
        }

        private void TurnRight(Car car)
        {
            car.Degree = CompassHelper.CompassToDegrees(car.Direction);
            car.Degree += Constants.R;
            car.Direction = CompassHelper.DegreesToCompass(car.Degree);
        }

        private void TurnLeft(Car car)
        {
            car.Degree = CompassHelper.CompassToDegrees(car.Direction);
            car.Degree -= Constants.L;
            car.Direction = CompassHelper.DegreesToCompass(car.Degree);
        }

        public void UpdateCollidate(Car car1, Car car2, Point position, int step)
        {
            if (car1.Collide == null)
            {
                car1.Collide = new Collide(car2, position, step);
            }
            if (car2.Collide == null)
            {
                car2.Collide = new Collide(car1, position, step);
            }
        }
    }
}
