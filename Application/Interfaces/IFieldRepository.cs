﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFieldRepository
    {
        public bool SetBoundary(Field field, string text);
        public void AddCar(Field field, Car car);
    }
}
