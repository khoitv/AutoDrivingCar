using AutoDrivingCar;
using System;
using System.Runtime.ConstrainedExecution;
Console.WriteLine("Welcome to Auto Driving Car Simulation!");

Build();
void Build()
{
    var field = new Field();
    Console.WriteLine("Please enter the width and height of the simulation field in x y format: ");
    var boundary = Console.ReadLine();
    while (!field.SetBoundary(boundary))
    {
        Console.WriteLine($"Boundary format is invalid ");
        Console.WriteLine("Please enter the width and height of the simulation field in x y format: ");
        boundary = Console.ReadLine();
    }

    Console.WriteLine($"You have created a field of {field.TextBoundary}.");
    Console.WriteLine("Please choose from the following options: ");
    Console.WriteLine("[1] Add a car to field");
    Console.WriteLine("[2] Run simulation");

    var selection = Console.ReadLine();
    while (selection == "1")
    {
        Console.WriteLine("Please enter the name of the car: ");
        var carName = Console.ReadLine();
        while (field.IsNameDuplicated(carName))
        {
            Console.WriteLine($"Name is duplicated");
            Console.WriteLine("Please enter the name of the car: ");
            carName = Console.ReadLine();
        }

        var car = new Car(carName);

        Console.WriteLine($"Please enter initial position of car {carName} in x y Direction format: ");
        var position = Console.ReadLine();
        while (!car.SetPosition(position))
        {
            Console.WriteLine($"Position format is invalid ");
            Console.WriteLine($"Please enter initial position of car {carName} in x y Direction format: ");
            position = Console.ReadLine();
        }

        Console.WriteLine($"Please enter the commands for car {carName}: ");
        car.Commands = Console.ReadLine();
        field.AddCar(car);

        Console.WriteLine("Your current list of cars are: ");
        Console.WriteLine("[1] Add a car to field");
        Console.WriteLine("[2] Run simulation");
        selection = Console.ReadLine();
    }

    if (selection == "2")
    {
        field.Cars.ForEach(car =>
        {
            Console.WriteLine($"- {car.Display()}");
        });

        field.Simulate();

        Console.WriteLine("After simulation, the result is: ");
        field.Cars.ForEach(car =>
        {
            Console.WriteLine($"- {car.ToString()}");
        });

        Console.WriteLine("[1] Start over");
        Console.WriteLine("[2] Exit");
        selection = Console.ReadLine();
        if (selection == "1")
        {
            Build();
        }
        else if (selection == "2")
        {
            Console.WriteLine(" Thank you for running the simulation. Goodbye!");
        }
    }
}