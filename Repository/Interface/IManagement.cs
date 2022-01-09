using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPISMART.Repository.Interface
{
    public interface IManagement
    {
        List<IEnumerable<Management>> GetAllManagement();
        Task<Management> GetManagementByID(int id);
        Task<Management> GetManagementByMarket();
        Task<Management> GetManagementByName();
        Task<Management> GetManagementByState();
    }
}
