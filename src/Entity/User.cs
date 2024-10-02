using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        // add annotation email is unique
        public string Email { get; set; }
        public string Password { get; set; }

        // private, protected
        public byte[]? Salt { get; set; }

        // role enum
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