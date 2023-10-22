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
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingBoy()
        {
            parkingLots.Add(new ParkingLot());
            parkingLots.Add(new ParkingLot());
        }

        internal List<ParkingLot> ParkingLots => parkingLots;

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
        public override string Park(string car)
        {
            ParkingLots.Sort((a, b) => a.AvaliablePosition() - b.AvaliablePosition());
            return base.Park(car);
        }
    }
 }
