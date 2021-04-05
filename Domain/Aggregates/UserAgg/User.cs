using Domain.Aggregates.ReservationAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.UserAgg
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
