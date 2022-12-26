﻿namespace FluentValidationApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public IList<Address>? Addresses { get; set; }

        public string GetFullName()
        {
            return $"{Name} - {Email} - {Age}";
        }
    }
}
 