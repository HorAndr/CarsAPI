using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; } 

    }
}
