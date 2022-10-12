using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class Lot
    {
        private Dictionary<Ticket, Car> lotSpace = new Dictionary<Ticket, Car>();
        private int size = 10;
        public Lot(int i)
        {
            size = i;
        }

        public Lot()
        {
        }

        public Ticket ParkingCar(Car car)
        {
            if (lotSpace.Count >= size)
            {
                throw new LotFullException("Not enough positions.");
            }

            var ticket = new Ticket(car);
            lotSpace.Add(ticket, car);
            return ticket;
        }

        public List<Ticket> ParkingCar(List<Car> cars)
        {
            var tickets = cars.Select(t => new Ticket(t)).ToList();
            for (var i = 0; i < tickets.Count; i++)
            {
                lotSpace.Add(tickets[i], cars[i]);
            }

            return tickets;
        }

        public Car PickUpCar(Ticket ticket)
        {
            if (!lotSpace.ContainsKey(ticket))
            {
                return null;
            }

            var pickUpCar = lotSpace[ticket];
            lotSpace.Remove(ticket);
            return pickUpCar;
        }

        public bool HasPosition(int carsCount)
        {
            var dictionary = this.lotSpace;
            return dictionary.Count + carsCount <= this.size;
        }

        public int GetPosition()
        {
            return this.size - this.lotSpace.Count;
        }

        public double GetVacancyRate()
        {
            var vacancyRate = 1 - ((float)lotSpace.Count / (float)size);
            return vacancyRate;
        }
    }
}