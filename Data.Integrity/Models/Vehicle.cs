using Data.Integrity.Custom;
using System;

namespace Data.Integrity.Models
{
    public class Vehicle
    {
        [Hash]
        public int Id { get; set; }
        public string Make { get; set; }
        [Hash]
        public string Model { get; set; }
        [Hash]
        public int Year { get; set; }
        [Hash]
        public double? Price { get; set; }
        [Hash]
        public int? Wheels { get; set; }
        public int Mileage { get; set; }
        [Hash]
        public string Plate { get; set; }
        [Hash]
        public DateTime? Date { get; set; }
        public string Concat { get; set; }
    }
}
