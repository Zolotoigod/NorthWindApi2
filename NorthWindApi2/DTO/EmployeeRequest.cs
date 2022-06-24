﻿using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class EmployeeRequest
    {
        [Required]
        [StringLength(20)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string? FirstName { get; set; }
        [StringLength(30)]
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }

        [Required]
        [StringLength(60)]
        public string? Address { get; set; }

        [Required]
        [StringLength(15)]
        public string? City { get; set; }

        [Required]
        [StringLength(15)]
        public string? Region { get; set; }

        [Required]
        [StringLength(15)]
        public string? Country { get; set; }

        [StringLength(24)]
        public string? HomePhone { get; set; }

        [StringLength(255)]
        public string? PhotoPath { get; set; }
    }
}
