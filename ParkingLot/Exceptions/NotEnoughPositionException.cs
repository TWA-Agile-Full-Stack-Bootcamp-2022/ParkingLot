using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Exceptions
{
    public class NotEnoughPositionException : Exception
    {
        public NotEnoughPositionException(string message) : base(message)
        {
        }
    }
}
