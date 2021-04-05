using ApplicationCore.DTO;
using AutoMapper;
using Domain.Aggregates.FoodTypeAgg;
using Domain.Aggregates.ReservationAgg;
using Domain.Aggregates.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Mappings
{
    public class MappingsProfile :Profile
    {

        public MappingsProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDetailsDTO>();
            CreateMap<FoodTypeDTO,FoodType>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
            CreateMap<AddReservationDTO, Reservation>();
        }
    }
}
