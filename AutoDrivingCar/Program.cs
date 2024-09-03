using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.ConstrainedExecution;
using Infratructure;
using Application.Interfaces;
using Domain;
using Application.Commons;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddServices();

using IHost host = builder.Build();
Build(host.Services);
await host.RunAsync();
static void Build(IServiceProvider hostProvider)
{
    Console.WriteLine("Welcome to Auto Driving Car Simulation!");
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    ISimulatorService simulatorService = provider.GetRequiredService<ISimulatorService>();
    var field = new Field();
    Console.WriteLine("Please enter the width and height of the simulation field in x y format: ");
    var boundary = Console.ReadLine();
    IFieldRepository fieldRepository = simulatorService.FieldRepository;
    ICarRepository carRepository = simulatorService.CarRepository;

    while (!fieldRepository.SetBoundary(field, boundary))
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
        var car = new Car();
        var carName = Console.ReadLine();
        while (field.IsNameDuplicated(carName))
        {
            Console.WriteLine($"Name is duplicated");
            Console.WriteLine("Please enter the name of the car: ");
            carName = Console.ReadLine();
        }

        car.Name = carName;
        Console.WriteLine($"Please enter initial position of car {carName} in x y Direction format: ");
        var position = Console.ReadLine();
        while (!carRepository.InitPosition(car, position))
        {
            Console.WriteLine($"Position format is invalid ");
            Console.WriteLine($"Please enter initial position of car {carName} in x y Direction format: ");
            position = Console.ReadLine();
        }

        Console.WriteLine($"Please enter the commands for car {carName}: ");
        car.Commands = Console.ReadLine();
        fieldRepository.AddCar(field, car);

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

        simulatorService.Simulate(field);

        Console.WriteLine("After simulation, the result is: ");
        field.Cars.ForEach(car =>
        {
            Console.WriteLine($"- {car.Result()}");
        });

        Console.WriteLine("[1] Start over");
        Console.WriteLine("[2] Exit");
        selection = Console.ReadLine();
        if (selection == "1")
        {
            Build(provider);
        }
        else if (selection == "2")
        {
            Console.WriteLine(" Thank you for running the simulation. Goodbye!");
        }
    }

}