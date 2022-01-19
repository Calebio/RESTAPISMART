using System;
using Elasticsearch.Net;
using Nest;

namespace SearchAPI
{
    public class ConnectionToNest
    {
        
        public ElasticLowLevelClient ElasticLowLevelClient { get;  }

        public ConnectionToNest()
        {
            var settings = new ConnectionSettings(new Uri("https://search-smart-apartment-data-test-shhsba3ijh7273p2dkt5hre5e4.us-east-1.es.amazonaws.com/mgmtindex")) .DefaultIndex("");

            this.ElasticLowLevelClient = new ElasticLowLevelClient(settings);
        }

   
    }
}
