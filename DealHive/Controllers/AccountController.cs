using System.Security.Claims;
using AutoMapper;
using Hive.Application.Dtos.Account;
using Hive.Application.Services;
using Hive.Core.Dtos.Account;
using Hive.Core.Entities;
using Hive.Core.Interfaces.AuthService;
using Hive.Core.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DealHive.Controllers
{
    
    public class AccountController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(IAuthService authService, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IMapper mapper
            )
        {
            _authService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        [HttpPost("login")]

        public async Task<ActionResult> Login(LoginDto model)
        {
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest();

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded == false)
            {
                return Unauthorized();
            }
            var token = _authService.GenerateToken(user);

            var userToReturn = _mapper.Map<AppUser, UserDto>(user);

            userToReturn.Token = token;

            return NewResult(ResponseHandler<UserDto>.Success(userToReturn));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            
            var userExistanceCheck = await _userManager.FindByEmailAsync(model.Email);

            if (userExistanceCheck is not null)
                return NewResult(ResponseHandler<AppUser>.BadRequest($"This email {userExistanceCheck} is taken"));

            var user = new AppUser() 
            {
                Email = model.Email,
                Name = model.UserName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errorDescriptions = result.Errors.Select(e => e.Description).ToList();
                return NewResult(ResponseHandler<AppUser>.BadRequest("Something went wrong creating your account, Please try again", errorDescriptions));

            }

            var token = _authService.GenerateToken(user);
            var userToReturn = _mapper.Map<AppUser, UserDto>(user);
            userToReturn.Token = token;


            return NewResult(ResponseHandler<UserDto>.Success(userToReturn));


        }
    }
}
