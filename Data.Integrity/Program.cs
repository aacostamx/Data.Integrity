using Data.Integrity.Custom;
using Data.Integrity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

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
                    Date = DateTime.Now
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

            ReadProperties(vehicles);
        }

        public static void ReadProperties<T>(List<T> list)
        {
            var props = typeof(T).GetProperties()
                .Where(atr => Attribute.IsDefined(atr, typeof(HashAttribute)))
                .ToList();

            foreach (T item in list)
            {
                var sb = new StringBuilder();
                foreach (PropertyInfo prop in props)
                {
                    sb.Append(prop.GetValue(item));
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(item)}");
                }
                Console.WriteLine(sb.ToString());
                string hash = GetHash(sb.ToString());
                Console.WriteLine(hash);
            }
        }

        private static string GetHash(string input)
        {
            using var md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            var sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();

            //using SHA256 sha256Hash = SHA256.Create();
            //byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            //var sb = new StringBuilder();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sb.Append(data[i].ToString("x2"));
            //}
            //return sb.ToString();
        }
    }
}
