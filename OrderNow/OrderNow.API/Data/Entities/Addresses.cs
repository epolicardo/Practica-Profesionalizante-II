﻿namespace Data.Entities
{
    public class Addresses : EntityBase
    {
        public string Street { get; set; } = String.Empty;
        public string  Number { get; set; } = String.Empty;
        public string? Floor { get; set; } = null;
        public string? Apartment { get; set; } = null;
        public string?  Tower { get; set; }
        public Cities? City { get; set; }
        public string? Observations { get; set; }


    }
}