using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        
        private CarContext _context;

        public CarController(CarContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
           
            return Ok(await _context.Cars.ToListAsync());
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return BadRequest("Car not found.");
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            var dbcar = await _context.Cars.FindAsync(request.Id);
            if (dbcar == null)
            {
                return BadRequest("Car not found.");
            }
            
            dbcar.Brand = request.Brand;
            dbcar.Model = request.Model;  
            dbcar.Year = request.Year;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Car>>> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return BadRequest("Car not found.");
            }
            
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }

    }
}
