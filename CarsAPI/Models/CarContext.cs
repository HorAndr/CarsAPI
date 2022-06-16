using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Car> Cars { get; set; }
    }
}
