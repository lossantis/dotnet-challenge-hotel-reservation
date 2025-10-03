using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel.Exceptions;

namespace hotel.Models
{
    public class Reservation(int bookedNights)
    {
        private List<Person> _guests = new();
        private Suite? _suite;
        private readonly int _bookedNights = bookedNights > 0 ? bookedNights : throw new BookedNightsLowerThanZeroException();

        private const int DiscountNightsThreshold = 10;
        private const decimal DiscountRate = 0.9M;

        public IReadOnlyList<Person> Guests => _guests.AsReadOnly();
        public Suite? Suite => _suite;
        public int BookedNights => _bookedNights;

        public void AddSuite(Suite suite)
        {
            if (suite is null)
                throw new SuiteIsNullException();

            if (_guests.Count > 0 && suite.Capacity < _guests.Count)
                throw new SuiteCapacityLowerThanGuestsException();

            _suite = suite;
        }

        public void AddGuest(Person guest)
        {
            if (guest is null)
            {
                throw new GuestIsNullException();
            }

            if (_suite is null)
            {
                throw new SuiteIsNullException();
            }

            if (_guests.Count + 1 > _suite.Capacity)
            {
                throw new ExceedSuiteCapacityException();
            }

            _guests.Add(guest);
        }

        public void AddGuests(IEnumerable<Person> guests)
        {
            if (guests is null)
            {
                throw new GuestIsNullException();
            }

            if (_suite is null)
            {
                throw new SuiteIsNullException();
            }

            var guestList = guests.ToList();

            if (_guests.Count + guestList.Count > _suite.Capacity)
            {
                throw new ExceedSuiteCapacityException();
            }

            _guests.AddRange(guestList);
        }

        
        public int GetGuestCount() => _guests.Count;
        
        public decimal CalculateDailyRate()
        {
            if (_suite is null)
            {
                throw new SuiteIsNullException();
            }

            decimal total = _bookedNights * _suite.PricePerNight;

            if (_bookedNights > 10)
            {
                total *= DiscountRate;
            }

            return total;
        }
    }
}