using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure
{
    public class FieldRepository : IFieldRepository
    {
        public void AddCar(Field field, Car car)
        {
            field.Cars.Add(car);
        }

        public bool SetBoundary(Field field, string text)
        {
            try
            {
                int x = int.Parse(text.Split(" ")[0].Trim());
                int y = int.Parse(text.Split(" ")[1].Trim());
                field.MaxBoundary = new Point(x, y);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
