using RESTAPISMART.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPISMART.Repository.Repo
{
    public class ManagementRepo : IManagement
    {
        public List<IEnumerable<Management>> GetAllManagement()
        {
            throw new NotImplementedException();
        }

        public Task<Management> GetManagementByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Management> GetManagementByMarket()
        {
            throw new NotImplementedException();
        }

        public Task<Management> GetManagementByName()
        {
            throw new NotImplementedException();
        }

        public Task<Management> GetManagementByState()
        {
            throw new NotImplementedException();
        }
    }
}
