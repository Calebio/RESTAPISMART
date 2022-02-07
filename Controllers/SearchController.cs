using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RESTAPISMART.Entity;
using System.Threading.Tasks;

namespace RESTAPISMART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPropRepo propRepo;

        public SearchController(IPropRepo propRepo)
        {
            this.propRepo = propRepo;
        }


    //[HttpGet]
    //public IEnumerable<Management> SearchMgmt(string searchPhrase)
    //{





    //}

        [HttpGet]
        public async Task<IActionResult> SearchProp(string searchPhrase)
        {
            try
            {
                return Ok(await propRepo.GetProperty(searchPhrase));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
}
}
