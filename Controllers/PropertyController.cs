using Microsoft.AspNetCore.Mvc;
using RESTAPISMART.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPISMART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProperties properties;

        public PropertyController(IProperties properties)
        {
            this.properties = properties;
        }

        [HttpGet]
        public void Search(string searchPhrase, int limit, string? market)
        {
            limit = 25;
            
        }
    }
}
