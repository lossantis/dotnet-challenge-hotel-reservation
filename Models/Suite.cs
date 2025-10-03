using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Models
{
    public class Suite(
        string suiteType,
        int capacity,
        decimal pricePerNight
    )
    {
        public string SuiteType { get; } = suiteType;
        public int Capacity { get; } = capacity;
        public decimal PricePerNight { get; } = pricePerNight;

        public void Deconstruct(out string suiteType, out int capacity, out decimal pricePerNight)
        {
            suiteType = SuiteType;
            capacity = Capacity;
            pricePerNight = PricePerNight;
        }
    }
}