using RESTAPISMART.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPISMART.Repository.Repo
{
    public class PropertiesRepo : IProperties
    {
        public List<IEnumerable<Properties>> GetProperties()
        {
            throw new NotImplementedException();
        }

        public Task<Properties> GetPropertyByFormer()
        {
            throw new NotImplementedException();
        }

        public Task<Properties> GetPropertyById(int PropID)
        {
            throw new NotImplementedException();
        }

        public Task<Properties> GetPropertyByMarket()
        {
            throw new NotImplementedException();
        }
    }
}
