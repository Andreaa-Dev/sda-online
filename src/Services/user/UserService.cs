using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.src.Entity;
using ecommerce.src.Repository;
using ecommerce.src.Utils;
using static ecommerce.src.DTO.UserDTO;

namespace ecommerce.src.Services.user
{
    public class UserService : IUserService
    {
        protected readonly UserRepository _userRepo;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;

        public UserService(UserRepository userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserReadDto> CreateOneAsync(UserCreateDto createDto)
        {
            PasswordUtils.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);

            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Password = hashedPassword;
            user.Salt = salt;
            user.Role = Role.Customer;
            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);

        }

        public async Task<string> SignInAsync(UserCreateDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            if (foundUser == null)
            {
                throw CustomException.NotFound($"Cant find user with {createDto.Email}");
            }
            var isMatched = PasswordUtils.VerifyPassword(createDto.Password, foundUser.Password, foundUser.Salt);

            if (isMatched)
            {
                var tokenUtil = new TokenUtils(_config);
                return tokenUtil.GenerateToken(foundUser);
            }
            throw CustomException.UnAuthorized($"user with {foundUser.Email} password does not match");
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var UserList = await _userRepo.GetAllAsync();
            return _mapper.Map<List<User>, List<UserReadDto>>(UserList);
        }


    }
}