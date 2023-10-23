using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots;

        public ParkingBoy()
        {
            parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot());
            parkingLots.Add(new ParkingLot());
        }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        private protected List<ParkingLot> ParkingLots => parkingLots;

        public virtual string Park(string car)
        {
            foreach (var lot in parkingLots)
            {
                if (lot.Avaliable())
                {
                    return lot.Park(car);
                }
                else
                {
                    continue;
                }
            }

            throw new InsufficientPositionException("Not enough position");
        }

        public string Fetch(string ticket)
        {
            foreach (var lot in parkingLots)
            {
                try
                {
                    return lot.Fetch(ticket);
                }
                catch (InvalidTicketException ex)
                {
                    continue;
                }
            }

            throw new InvalidTicketException("Unrecognized parking ticket");
        }

        public int GetCapacity()
        {
            int sum = 0;
            foreach (var lot in parkingLots)
            {
                sum += lot.Capacity;
            }

            return sum;
        }
    }

    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy()
        {
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override string Park(string car)
        {
            ParkingLots.Sort((a, b) => b.AvailablePosition().CompareTo(a.AvailablePosition()));
            return base.Park(car);
        }
    }

    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy()
        {
        }

        public SuperSmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override string Park(string car)
        {
            ParkingLots.Sort((a, b) => b.AvailableRate().CompareTo(a.AvailableRate()));
            return base.Park(car);
        }
    }
 }
