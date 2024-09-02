using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoDrivingCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCar.Tests
{
    [TestClass()]
    public class FieldTests
    {
        [TestMethod()]
        public void SimulateTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            field.Simulate();
            Assert.AreEqual(4, carA.Position.X);
            Assert.AreEqual(3, carA.Position.Y);
            Assert.AreEqual('S', carA.Direction);
        }

        [TestMethod()]
        public void SimulateTwoCarsTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            var carB = new Car("B");
            carB.SetPosition("7 8 W");
            carB.Commands = "FFLFFFFFFF";
            field.AddCar(carB);

            field.Simulate();
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
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            var carB = new Car("B");
            carB.SetPosition("7 8 W");
            carB.Commands = "FFLFFFFFFF";
            field.AddCar(carB);

            var carC = new Car("C");
            carC.SetPosition("7 6 S");
            carC.Commands = "FFRFFFF";
            field.AddCar(carC);

            field.Simulate();
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
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            var carB = new Car("B");
            carB.SetPosition("6 8 W");
            carB.Commands = "FFLFFFFFFF";
            field.AddCar(carB);

            field.Simulate();
            Assert.AreEqual(carA.Collide.By.Name, carB.Name);
            Assert.AreEqual(4, carA.Collide.Position.X);
            Assert.AreEqual(4, carA.Collide.Position.Y);
            Assert.AreEqual(7, carA.Collide.Step);
        }

        [TestMethod()]
        public void CollidateThreeCarsTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            var carB = new Car("B");
            carB.SetPosition("6 8 W");
            carB.Commands = "FFLFFFFFFF";
            field.AddCar(carB);

            var carC = new Car("C");
            carC.SetPosition("7 6 S");
            carC.Commands = "FFRFFFF";
            field.AddCar(carC);

            field.Simulate();
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
            Field field = new Field();
            field.MaxBoundary = new Point(5, 5);
            var carA = new Car("A");
            carA.SetPosition("2 5 N");
            carA.Commands = "FF";
            field.AddCar(carA);

            field.Simulate();
            Assert.AreEqual(5, carA.Position.Y);
        }


        [TestMethod()]
        public void BeyondBoundarySouthTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(5, 5);
            var carA = new Car("A");
            carA.SetPosition("2 0 S");
            carA.Commands = "FF";
            field.AddCar(carA);

            field.Simulate();
            Assert.AreEqual(0, carA.Position.Y);
        }

        [TestMethod()]
        public void BeyondBoundaryWestTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(5, 5);
            var carA = new Car("A");
            carA.SetPosition("0 2 W");
            carA.Commands = "FF";
            field.AddCar(carA);

            field.Simulate();
            Assert.AreEqual(0, carA.Position.X);
        }

        [TestMethod()]
        public void BeyondBoundaryEastTest()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(5, 5);
            var carA = new Car("A");
            carA.SetPosition("5 0 E");
            carA.Commands = "FF";
            field.AddCar(carA);

            field.Simulate();
            Assert.AreEqual(5, carA.Position.X);
        }


        [TestMethod()]
        public void DuplicatedName()
        {
            Field field = new Field();
            field.MaxBoundary = new Point(10, 10);
            var carA = new Car("A");
            carA.SetPosition("1 2 N");
            carA.Commands = "FFRFFFRRLF";
            field.AddCar(carA);

            Assert.IsTrue(field.IsNameDuplicated("A"));
        }
    }
}