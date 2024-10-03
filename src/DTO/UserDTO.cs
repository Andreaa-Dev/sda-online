using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Entity;
using ecommerce.src.Utils;

namespace ecommerce.src.DTO
{
    public class UserDTO
    {
        public class UserReadDto
        {
            public Guid Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
        }

        public class UserCreateDto
        {
            public string Email { get; set; }
            [PasswordComplexity]
            public string Password { get; set; }
        }

        // update

        // DTO -email
        public class UserUpdateDto
        {
            public string? Email { get; set; }
            public string? Password { get; set; }

        }


    }
}