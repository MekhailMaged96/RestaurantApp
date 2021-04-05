using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumOfPeople { get; set; }
        public FoodTypeDTO FoodType { get; set; }
        public int FoodTypeId { get; set; }
        public string Notes { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
