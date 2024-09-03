using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISimulatorService
    {
        IFieldRepository FieldRepository { get; }
        ICarRepository CarRepository { get; }
        Field Simulate(Field field);
    }
}
