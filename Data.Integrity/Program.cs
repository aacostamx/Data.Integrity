using Data.Integrity.Models;
using System;
using System.Collections.Generic;

namespace Data.Integrity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var vehicles = new List<Vehicle> {
                new Vehicle
                {
                    Id = 1,
                    Make = "Mazda",
                    Model = "Mazda 6",
                    Year = 2020,
                    Price = 40000,
                    Wheels = 4,
                    Mileage = 0,
                    Plate = "847 RB5",
                    Date = new DateTime(2020-12-05)
                },
                new Vehicle
                {
                    Id = 2,
                    Make = "Mercedes-Benz",
                    Model = "CLA",
                    Year = 2020,
                    Price = 600000,
                    Mileage = 0,
                    Plate = "851 TD3"
                },
                new Vehicle
                {
                    Id = 3,
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    Price = 450000,
                    Mileage = 0,
                    Plate = "984 RT4"
                },
            };

            List<string> original = HashUtility.ListToHash(vehicles);

            vehicles[0].Model = "2019";
            vehicles[1].Plate = "947 WE3";

            List<string> modified = HashUtility.ListToHash(vehicles);

            for (var i = 0; i < original.Count; i++)
            {
                if (original[i].Equals(modified[i]))
                {
                    Console.WriteLine("Original");
                    Console.WriteLine(original[i]);
                    Console.WriteLine(modified[i]);
                }
                else
                {
                    Console.WriteLine("Modified");
                    Console.WriteLine(original[i]);
                    Console.WriteLine(modified[i]);
                }
            }
        }
    }
}
