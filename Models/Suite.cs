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
        private readonly string _suiteType = suiteType;
        private readonly int _capacity = capacity;
        private readonly decimal _pricePerNight = pricePerNight;

        public string SuiteType => _suiteType;
        public int Capacity => _capacity;
        public decimal PricePerNight => _pricePerNight;

        public void Deconstruct(out string suiteType, out int capacity, out decimal pricePerNight)
        {
            suiteType = SuiteType;
            capacity = Capacity;
            pricePerNight = PricePerNight;
        }
    }
}