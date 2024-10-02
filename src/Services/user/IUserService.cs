using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ecommerce.src.DTO.UserDTO;

namespace ecommerce.src.Services.user
{
    public interface IUserService
    {
        Task<UserReadDto> CreateOneAsync(UserCreateDto createDto);
        // UserSignInDto
        Task<string> SignInAsync(UserCreateDto createDto);

        Task<List<UserReadDto>> GetAllAsync();


    }
}