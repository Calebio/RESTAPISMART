using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RESTAPISMART.Entity;
using System.Threading.Tasks;
using static RESTAPISMART.Entity.Models;

namespace RESTAPISMART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        //SearchAPI.ConnectionToNest SearchApi;

        ElasticClient ElasticClient;

        public SearchController()
        {
            var uri = new Uri("https://testuser-elssrch:@Caleb55446@search-smart-apartment-data-test-shhsba3ijh7273p2dkt5hre5e4.us-east-1.es.amazonaws.com/mgmtindex");
            //var settings = new ConnectionConfiguration(uri);
            var settings = new ConnectionSettings(uri);
            //SearchApi = new SearchAPI.ConnectionToNest();
            ElasticClient = new ElasticClient(settings);
        }

        [Required]
        public string searchPhrase { get; set; }
        public string market { get; set; }
        public int limit = 25;

        //to respond to search
        

        
        public Property Properties { get; set; }

        public Management Managements { get; set; }

        [HttpGet]
        public IEnumerable<Management> Search(string searchPhrase)
        {


            if (market == Managements.market)
            {

                var result = ElasticClient.Search<Management>();
                return result.Documents;


            }

            var response = ElasticClient.Search<Management>(s => s
            .Index("mgmtindex") //or specify index via settings.DefaultIndex("mytweetindex");
            .From(0)
            .Size(limit)
            .Query(q => q
            .Term(t => t.market, searchPhrase) || q
            .Match(mq => mq.Field(f => f.market).Query("*"))
     )
 );
            return response.Documents;
        }   
            
        [HttpGet]
        public IEnumerable<Property> SearchProp(string searchPhrase)
        {

            if(market == Properties.market)
            {
                var result = ElasticClient.Search<Property>();
                return result.Documents;
            }
           

            var response = ElasticClient.Search<Property>(s => s
            .Index("propertyindex")
            .From(0)
            .Size(limit)
            .Query(q => q
            .Term(t => t.name, searchPhrase) || q
            .Match(mq => mq.Field(f => f.name).Query("*"))
            )
    );
            return response.Documents;
        }

        //[HttpPost]
        //public Task<IActionResult> PostMgmtData()
        //{
        //    var json =
        //}

        //public Task<IActionResult> PostPropertyData()
        //{

        //}

    }
}
