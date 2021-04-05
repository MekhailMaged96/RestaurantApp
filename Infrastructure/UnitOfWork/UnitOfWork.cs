
using Domain.Aggregates.FoodTypeAgg;
using Domain.Aggregates.ReservationAgg;
using Domain.Aggregates.UserAgg;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private IRepository<User> _UserRepo;

        public IRepository<User> UserRepo
        {
            get
            {
                return this._UserRepo = this._UserRepo ?? new Repository<User>(_context);
            }
        }

        private IRepository<Reservation> _ReservationRepo;

        public IRepository<Reservation> ReservationRepo
        {
            get
            {
                return this._ReservationRepo = this._ReservationRepo ?? new Repository<Reservation>(_context);
            }
        }


        private IRepository<FoodType> _FoodTypeRepo;

        public IRepository<FoodType> FoodTypeRepo
        {
            get
            {
                return this._FoodTypeRepo = this._FoodTypeRepo ?? new Repository<FoodType>(_context);
            }
        }
        public async Task<bool> SaveAsync()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                    return true;

                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    //todo: Log the error
                    return false;
                    throw ex;

                }
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
