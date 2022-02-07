using Nest;
using System;

namespace RESTAPISMART.Data
{
    public class SearchContext : ElasticClient
    {
        public ElasticClient ElasticClient { get; }

        public SearchContext()
        {
            var uri = new Uri("https://testuser-elssrch:@Caleb55446@search-smart-apartment-data-test-shhsba3ijh7273p2dkt5hre5e4.us-east-1.es.amazonaws.com/mgmtindex");
            var settings = new ConnectionSettings(uri);
            //SearchApi = new SearchAPI.ConnectionToNest();
            ElasticClient = new ElasticClient(settings);
        }
       
    }
}
