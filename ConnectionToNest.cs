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
            var settings = new ConnectionSettings(new Uri("uri from aws elasticSearch")) .DefaultIndex("markets");

            this.ElasticLowLevelClient = new ElasticLowLevelClient(settings);
        }

   
    }
}
