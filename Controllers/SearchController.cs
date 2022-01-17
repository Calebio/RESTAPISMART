using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPISMART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        SearchAPI.ConnectionToNest SearchApi;

        ElasticClient ElasticClient;

        public SearchController()
        {
            var uri = new Uri("https://search-smart-apartment-data-test-shhsba3ijh7273p2dkt5hre5e4.us-east-1.es.amazonaws.com/mgmtindex");
            //var settings = new ConnectionConfiguration(uri);
            var settings = new ConnectionSettings(uri);
            //SearchApi = new SearchAPI.ConnectionToNest();
            ElasticClient = new ElasticClient(settings);
        }

        [Required]
        public string searchPhrase { get; set; }
        public string? market { get; set; }
        public int limit { get; set; }

        //to respond to search
        

        
        public Property Property { get; set; }

        [HttpGet]
        public IEnumerable<Management> Search(string searchPhrase)
        {
            var result = ElasticClient.Search<Management>();
            return result.Documents;


            var response = ElasticClient.Search<Management>(s => s
            .Index("mgmtindex") //or specify index via settings.DefaultIndex("mytweetindex");
            .From(0)
            .Size(limit)
            .Query(q => q
            .Term(t => t.market, "*" ) || q
            .Match(mq => mq.Field(f => f.market).Query("*"))
     )
 );
            return response.Documents;


        }
        [HttpGet]
        public IEnumerable<Property> SearchProp(string searchPhrase)
        {
            var result = ElasticClient.Search<Property>();

            var response = ElasticClient.Search<Property>(s => s
            .Index("propertyindex")
            .From(0)
            .Size(limit)
            .Query(q => q
            .Term(t => t.name, "*") || q
            .Match(mq => mq.Field(f => f.name).Query("*"))
            )
    );
            return response.Documents;
        }

    }
}
