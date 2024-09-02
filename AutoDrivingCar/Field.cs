using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCar
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

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public bool SetBoundary(string text)
        {
            try
            {
                int x = int.Parse(text.Split(" ")[0].Trim());
                int y = int.Parse(text.Split(" ")[1].Trim());
                MaxBoundary = new Point(x, y);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Simulate()
        {
            int maxStep = MaxStep;
            for (int step = 0; step < maxStep; step++)
            {
                var availableCars = Cars.Where(o => o.Collide == null).ToList();
                for (int i = 0; i < availableCars.Count; i++)
                {
                    availableCars[i].Move(step, MinBoundary, MaxBoundary);
                }

                CheckCollide(step);
            }
        }

        private void CheckCollide(int step)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                var car1 = Cars[i];
                for (int j = i + 1; j < Cars.Count; j++)
                {
                    var car2 = Cars[j];
                    if (car1.Collide != null && car2.Collide != null)
                    {
                        continue;
                    }
                    if (car1.Position.X == car2.Position.X && car1.Position.Y == car2.Position.Y)
                    {
                        car1.UpdateCollidate(car2, car1.Position, step + 1);
                        car2.UpdateCollidate(car1, car2.Position, step + 1);
                    }
                }
            }
        }

        public string TextBoundary => $"{MaxBoundary.X} x {MaxBoundary.Y}";

        private int MaxStep => Cars.Max(o => o.Commands.Length);
    }

    public static class FieldExtensions
    {
        public static bool IsNameDuplicated(this Field field, string name)
        {
            return field.Cars.Any(o => o.Name == name);
        }
    }
}
