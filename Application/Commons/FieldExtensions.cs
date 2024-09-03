using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
{
    public static class FieldExtensions
    {
        public static int MaxStep(this Field field) => field.Cars.Max(o => o.Commands.Length);

        public static string TextBoundary(this Field field) => $"{field.MaxBoundary.X} x {field.MaxBoundary.Y}";

        public static bool IsNameDuplicated(this Field field, string name)
        {
            return field.Cars.Any(o => o.Name == name);
        }
    }
}
