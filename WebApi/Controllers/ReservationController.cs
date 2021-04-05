using ApplicationCore.DTO;
using ApplicationCore.Services.ReservationService;
using AutoMapper;
using Domain.Aggregates.ReservationAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ReservationController : BaseController
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService,IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            int userId = GetUserId();

            var rese= await _reservationService.GetReservationsByUser(userId);

            var allreser = _mapper.Map<IEnumerable<ReservationDTO>>(rese);
            return Ok(allreser);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AddReservationDTO reservationDTO)
        {
            var reservation= _mapper.Map<Reservation>(reservationDTO);
            reservation.UserId = GetUserId();

            var rese = await _reservationService.AddReservation(reservation);

            return Ok(rese);
        }

        [HttpGet]
        [Route("GetFoodTypes")]
        public async Task<IActionResult> GetFoodTypes()
        {
          
            var rese = await _reservationService.GetFoodTypes();

            return Ok(rese);
        }

    }
}
