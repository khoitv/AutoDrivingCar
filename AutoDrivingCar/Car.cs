using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCar
{
    public class Car
    {
        public Car(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Point Position { get; private set; }
        public char Direction { get; private set; }
        public string Commands { get; set; }
        private int Degree { get; set; }

        public bool SetPosition(string text)
        {
            try
            {
                int x = int.Parse(text.Split(" ")[0].Trim());
                int y = int.Parse(text.Split(" ")[1].Trim());
                char direction = char.Parse(text.Split(" ")[2].Trim());
                Position = new Point(x, y);
                Direction = direction;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Move(int step, Point minBoundary, Point maxBoundary)
        {
            if (step <= Commands.Length)
            {
                var command = Commands[step];
                if (command == 'F')
                {
                    MoveForward(minBoundary, maxBoundary);
                }
                if (command == 'R')
                {
                    TurnRight();
                }
                if (command == 'L')
                {
                    TurnLeft();
                }
            }
        }

        private void MoveForward(Point minBoundary, Point maxBoundary)
        {
            if (Direction == Constants.N)
            {
                if (Position.Y + Constants.F <= maxBoundary.Y)
                    Position.Y += Constants.F;
            }
            else if (Direction == Constants.S)
            {
                if (Position.Y - Constants.F >= minBoundary.Y)
                    Position.Y -= Constants.F;
            }
            else if (Direction == Constants.E)
            {
                if (Position.X + Constants.F <= maxBoundary.X)
                    Position.X += Constants.F;
            }
            else if (Direction == Constants.W)
            {
                if (Position.X - Constants.F >= minBoundary.X)
                    Position.X -= Constants.F;
            }
        }

        private void TurnRight()
        {
            Degree = CompassHelper.CompassToDegrees(Direction);
            Degree += Constants.R;
            Direction = CompassHelper.DegreesToCompass(Degree);
        }

        private void TurnLeft()
        {
            Degree = CompassHelper.CompassToDegrees(Direction);
            Degree -= Constants.L;
            Direction = CompassHelper.DegreesToCompass(Degree);
        }


        public Collide Collide { get; set; }

        public void UpdateCollidate(Car collidateBy, Point position, int step)
        {
            if (Collide == null)
            {
                Collide = new Collide(collidateBy, position, step);
            }
        }

        public override string ToString()
        {
            if (Collide != null)
                return $"{this.Name}, collides with {Collide.By.Name} at {this.Position.ToString()} at step {Collide.Step}";

            return $"{this.Name}, ({this.Position.X},{this.Position.Y}) {this.Direction}";
        }

        public string Display() => $"{this.ToString()}, {this.Commands}";
    }
}
