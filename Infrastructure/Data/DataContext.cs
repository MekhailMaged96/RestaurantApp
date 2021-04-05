using Domain.Aggregates.FoodTypeAgg;
using Domain.Aggregates.ReservationAgg;
using Domain.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
   

    }
}
