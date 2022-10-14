using System;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket()
        {
            TicketNo = GenerateTicketNo();
        }

        public string TicketNo { get; set; }

        public override bool Equals(object obj)
        {
            var ticket = obj as Ticket;
            return ticket != null && Equals(ticket);
        }

        public override int GetHashCode()
        {
            return TicketNo != null ? TicketNo.GetHashCode() : 0;
        }

        private bool Equals(Ticket other)
        {
            return TicketNo == other.TicketNo;
        }

        private string GenerateTicketNo()
        {
            var currentTimeStamp = DateTime.Now.ToString("yyMMddHHmmssff");
            var randomNumberWith4Digits = new Random().Next(1000, 9999);
            return $"P{currentTimeStamp}{randomNumberWith4Digits}";
        }
    }
}