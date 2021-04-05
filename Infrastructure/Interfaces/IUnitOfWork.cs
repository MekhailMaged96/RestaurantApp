
using Domain.Aggregates.FoodTypeAgg;
using Domain.Aggregates.ReservationAgg;
using Domain.Aggregates.UserAgg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<User> UserRepo { get; }
        IRepository<Reservation> ReservationRepo { get; }
        IRepository<FoodType> FoodTypeRepo { get; }
        Task<bool> SaveAsync();

    }
}
