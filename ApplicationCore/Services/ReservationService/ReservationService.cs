using Domain.Aggregates.ReservationAgg;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddReservation(Reservation reservation)
        {
            _unitOfWork.ReservationRepo.Insert(reservation);
            if (await _unitOfWork.SaveAsync()) {

                return true;
            };

            return false;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUser(int userId)
        {
            var reservations =await _unitOfWork.ReservationRepo.GetAllAsync(e => e.UserId == userId, null, "FoodType,User");


            return reservations;
        }
    }
}
