using Domain.Aggregates.ReservationAgg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.ReservationService
{
    public interface IReservationService
    {

        public Task<IEnumerable<Reservation>> GetReservationsByUser(int userId);
        public Task<bool> AddReservation(Reservation reservation);


    }
}
