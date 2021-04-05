using Domain.Aggregates.FoodTypeAgg;
using Domain.Aggregates.UserAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.ReservationAgg
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumOfPeople { get; set; }
        public FoodType FoodType { get; set; }
        public int FoodTypeId { get; set; }
        public string Notes { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
