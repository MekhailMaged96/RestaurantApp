using ApplicationCore.DTO;
using ApplicationCore.Services.AccountService;
using ApplicationCore.Services.JWTService;
using AutoMapper;
using Domain.Aggregates.UserAgg;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IJWTService _jWTService;

        public AccountController(IUnitOfWork unitOfWork,IAccountService accountService, IMapper mapper,IJWTService jWTService )
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _mapper = mapper;
            _jWTService = jWTService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string UserName = userDTO.UserName.ToLower();

            if (await _accountService.UserExists(UserName))
            {
                return BadRequest("User Name is already exists");
            }
            var user = _mapper.Map<User>(userDTO);

            await _accountService.Register(user, userDTO.Password);

            var token = _jWTService.GenerateJWTToken(user);
            var userdt = _mapper.Map<UserDetailsDTO>(user);

            return Ok(new
            {
                token = token,
                user = userdt
            });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var userfromrepo = await _accountService.Login(userDTO.UserName.ToLower(), userDTO.Password);

            if (userfromrepo == null)
            {
                return Unauthorized();
            }

            var token = _jWTService.GenerateJWTToken(userfromrepo);

            var user = _mapper.Map<UserDetailsDTO>(userfromrepo);
            return Ok(new
            {

                token = token,
                user = user
            });
        }
    }
}
