using RESTAPISMART.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RESTAPISMART.Entity.Models;

namespace RESTAPISMART.Controllers
{
    public interface IPropRepo
    {
        Task<IEnumerable<Property>> GetProperties(string searchPhrase);
        Task<Property> GetProperty(string name);
        Task<Property> GetPropertyByMarket(string Mrktname);
        Task<Property> GetPropertyByCity(string CityName);
        Task<Property> GetPropertyByState(string state);
    }
}
