using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ecommerce.src.Utils;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.src.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        // add annotation email is unique
        [EmailAddress(ErrorMessage = "Please provide email with right format: @gmail.com ")]

        public string Email { get; set; }

        [PasswordComplexity]
        public string Password { get; set; }

        public byte[]? Salt { get; set; }


        public Role Role { get; set; } = Role.Customer;


    }

    // role
    // convert int => string : Admin + Customer
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        Customer
    }
}