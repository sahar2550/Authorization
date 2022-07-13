using AuthorizationWebApi.Data;
using AuthorizationWebApi.Models;
using AuthorizationWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationWebApi.Services
{
    public class CarService : ICarService
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        DbContextOptionsBuilder<DatabaseContext> _optionsBuilder;

        public CarService(IConfiguration configuration)
        {
            _configuration = configuration;
            _optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _optionsBuilder.UseSqlServer(_connectionString);
        }
        public async Task<Car> AddCar(Car car)
        {
            using (var context = new DatabaseContext(_optionsBuilder.Options) )
            {
                context.Cars.Add(car);
                await context.SaveChangesAsync();
            }

            return car;
        }

        public async Task<List<Car>> GetCars()
        {
            var cars = new List<Car>();
            using (var context = new DatabaseContext(_optionsBuilder.Options))
            {
                 cars = await context.Cars.ToListAsync();
            }

            return cars;
        }
    }
}
