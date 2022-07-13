using AuthorizationWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorizationWebApi.Services.Interfaces
{
    public interface ICarService
    {
        Task<Car> AddCar(Car eventViewModel);
        Task<List<Car>> GetCars();
    }
}
