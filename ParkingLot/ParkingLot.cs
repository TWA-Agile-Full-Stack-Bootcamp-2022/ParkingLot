namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // NOTE: Domain driven design & UML for OO
    // NOTE: The presence or absence of Parking Lot and Parking Boy on each other determines which class the method should belong to. park and fetch should belong to Parking Lot, because a car does not necessarily have to have the same parking boy to park and pick up the car. Parking Lot also could have multiple parking boys. From a UML class diagram perspective, the parking boy relies on parking lots
    public class ParkingLot
    {
        private const int Capacity = 10;
        // NOTE: Do not use Enumerable.Repeat(new ParkingTicket(), Capacity).ToList() to initialize the tickets as all member are same if yo do so
        // private readonly List<ParkingTicket> tickets = Enumerable.Repeat(new ParkingTicket(), Capacity).ToList();
        // NOTE: use Enumerable.Range to initialize a list field
        private readonly List<ParkingTicket> tickets = Enumerable.Range(1, Capacity).Select(i => new ParkingTicket()).ToList();
        private List<Car> parkedCars = new List<Car>(Capacity);

        public ParkingTicket ParkCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            if (parkedCars.Contains(car))
            {
                throw new InvalidOperationException("Car is already parked");
            }

            if (parkedCars.Count >= Capacity)
            {
                return null;
            }

            parkedCars.Add(car);
            var ticket = tickets.First(ticket => ticket.Issued == false);
            ticket.Issue(car.LicensePlate);
            return ticket;
        }

        public Car FetchCar(ParkingTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            if (ticket.Used == true)
            {
                throw new InvalidOperationException("Ticket has already been used");
            }

            if (!tickets.Contains(ticket))
            {
                throw new InvalidOperationException("Wrong ticket");
            }

            var car = parkedCars.Find(car => car.LicensePlate == ticket.LicensePlate);
            parkedCars.Remove(car);
            ticket.Retrieve();
            return car;
        }
    }
}
