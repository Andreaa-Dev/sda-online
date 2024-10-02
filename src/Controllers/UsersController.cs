using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Services.user;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ecommerce.src.DTO.UserDTO;

namespace ecommerce.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        protected readonly IUserService _userService;
        public UsersController(IUserService service)
        {
            _userService = service;
        }


        // create
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto createDto)
        {
            var UserCreated = await _userService.CreateOneAsync(createDto);
            //return Created($"api/v1/users/{UserCreated.Id}", UserCreated);
            return Ok(UserCreated);
        }

        // log in

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignInUser([FromBody] UserCreateDto createDto)
        {
            var token = await _userService.SignInAsync(createDto);
            //return Created($"api/v1/users/{UserCreated.Id}", UserCreated);
            return Ok(token);
        }


        // get all users
        [HttpGet]
        //[Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserReadDto>>> GetAllAsync()
        {
            var UserList = await _userService.GetAllAsync();
            return Ok(UserList);
        }

        // update user infor

        // create admin
        // admin@gmail.com
        // password
        // change role => admin


    }
}