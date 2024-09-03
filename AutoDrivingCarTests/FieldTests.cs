using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoDrivingCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Application.Interfaces;
using Infratructure;
using Application.Commons;

namespace AutoDrivingCar.Tests
{
    [TestClass()]
    public class FieldTests
    {
        [TestMethod()]
        public void Scenarior1()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);

            var car = act.Cars.FirstOrDefault();
            Assert.AreEqual(4, carA.Position.X);
            Assert.AreEqual(3, carA.Position.Y);
            Assert.AreEqual('S', carA.Direction);
        }

        [TestMethod()]
        public void Scenarior2Test()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var carB = new Car() { Name = "B", Position = new Point(7, 8), Direction = 'W', Commands = "FFLFFFFFFF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);
            field.Cars.Add(carB);
            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);

            Assert.AreEqual(4, carA.Position.X);
            Assert.AreEqual(3, carA.Position.Y);
            Assert.AreEqual('S', carA.Direction);


            Assert.AreEqual(5, carB.Position.X);
            Assert.AreEqual(1, carB.Position.Y);
            Assert.AreEqual('S', carB.Direction);
        }


        [TestMethod()]
        public void ThreeCarsTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var carB = new Car() { Name = "B", Position = new Point(7, 8), Direction = 'W', Commands = "FFLFFFFFFF" };
            var carC = new Car() { Name = "C", Position = new Point(7, 6), Direction = 'S', Commands = "FFRFFFF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);
            field.Cars.Add(carB);
            field.Cars.Add(carC);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);

            Assert.AreEqual(carA.Collide.By.Name, carC.Name);
            Assert.AreEqual(carC.Collide.By.Name, carA.Name);
            Assert.AreEqual(4, carA.Collide.Position.X);
            Assert.AreEqual(4, carA.Collide.Position.Y);
            Assert.AreEqual(6, carA.Collide.Step);

            Assert.AreEqual(5, carB.Position.X);
            Assert.AreEqual(1, carB.Position.Y);
            Assert.AreEqual('S', carB.Direction);
        }

        [TestMethod()]
        public void CollidateTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var carB = new Car() { Name = "B", Position = new Point(6, 8), Direction = 'W', Commands = "FFLFFFFFFF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);
            field.Cars.Add(carB);
            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);

            Assert.AreEqual(carA.Collide.By.Name, carB.Name);
            Assert.AreEqual(4, carA.Collide.Position.X);
            Assert.AreEqual(4, carA.Collide.Position.Y);
            Assert.AreEqual(7, carA.Collide.Step);
        }

        [TestMethod()]
        public void CollidateThreeCarsTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var carB = new Car() { Name = "B", Position = new Point(6, 8), Direction = 'W', Commands = "FFLFFFFFFF" };
            var carC = new Car() { Name = "C", Position = new Point(7, 6), Direction = 'S', Commands = "FFRFFFF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);
            field.Cars.Add(carB);
            field.Cars.Add(carC);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);
            Assert.AreEqual(carA.Collide.By.Name, carC.Name);
            Assert.AreEqual(carC.Collide.By.Name, carA.Name);
            Assert.AreEqual(4, carA.Collide.Position.X);
            Assert.AreEqual(4, carA.Collide.Position.Y);
            Assert.AreEqual(6, carA.Collide.Step);
            Assert.AreEqual(carB.Collide.By.Name, carA.Name);
            Assert.AreEqual(7, carB.Collide.Step);
        }

        [TestMethod()]
        public void BeyondBoundaryNorthTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(2, 5), Direction = 'N', Commands = "FF" };
            var field = new Field() { MaxBoundary = new Point(5, 5) };
            field.Cars.Add(carA);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);

            Assert.AreEqual(5, carA.Position.Y);
        }


        [TestMethod()]
        public void BeyondBoundarySouthTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(2, 0), Direction = 'S', Commands = "FF" };
            var field = new Field() { MaxBoundary = new Point(5, 5) };
            field.Cars.Add(carA);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);
            Assert.AreEqual(0, carA.Position.Y);
        }

        [TestMethod()]
        public void BeyondBoundaryWestTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(0, 2), Direction = 'W', Commands = "FF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);
            Assert.AreEqual(0, carA.Position.X);
        }

        [TestMethod()]
        public void BeyondBoundaryEastTest()
        {
            var carA = new Car() { Name = "A", Position = new Point(5, 0), Direction = 'E', Commands = "FF" };
            var field = new Field() { MaxBoundary = new Point(5, 5) };
            field.Cars.Add(carA);

            var fieldRepo = new FieldRepository();
            var carRepo = new CarRepository();
            var simulatorService = new SimulatorService(fieldRepo, carRepo);
            var act = simulatorService.Simulate(field);
            Assert.AreEqual(5, carA.Position.X);
        }


        [TestMethod()]
        public void DuplicatedName()
        {
            var carA = new Car() { Name = "A", Position = new Point(1, 2), Direction = 'N', Commands = "FFRFFFRRLF" };
            var field = new Field() { MaxBoundary = new Point(10, 10) };
            field.Cars.Add(carA);

            Assert.IsTrue(field.IsNameDuplicated("A"));
        }
    }
}