using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure
{
    public class SimulatorService : ISimulatorService
    {
        public IFieldRepository FieldRepository { get; }

        public ICarRepository CarRepository { get; }

        public SimulatorService(IFieldRepository fieldRepository, ICarRepository carRepository)
        {
            FieldRepository = fieldRepository;
            CarRepository = carRepository;
        }

        public Field Simulate(Field field)
        {
            int maxStep = field.Cars.Max(o => o.Commands.Length);
            for (int step = 0; step < maxStep; step++)
            {
                var availableCars = field.Cars.Where(o => o.Collide == null).ToList();
                for (int i = 0; i < availableCars.Count; i++)
                {
                    CarRepository.Move(availableCars[i], step, field.MinBoundary, field.MaxBoundary);
                }

                CheckCollide(field, step);
            }

            return field;
        }

        private void CheckCollide(Field field, int step)
        {
            for (int i = 0; i < field.Cars.Count; i++)
            {
                var car1 = field.Cars[i];
                for (int j = i + 1; j < field.Cars.Count; j++)
                {
                    var car2 = field.Cars[j];
                    if (car1.Collide != null && car2.Collide != null)
                    {
                        continue;
                    }

                    if (car1.Position.X == car2.Position.X && car1.Position.Y == car2.Position.Y)
                    {
                        CarRepository.UpdateCollidate(car1, car2, car1.Position, step + 1);
                    }
                }
            }
        }
    }
}
