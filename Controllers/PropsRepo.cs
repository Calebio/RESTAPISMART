using Elasticsearch.Net;
using Nest;
using RESTAPISMART.Data;
using RESTAPISMART.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RESTAPISMART.Entity.Models;

namespace RESTAPISMART.Controllers
{
    public class PropsRepo : IPropRepo
    {
        //private Elasticsearch.Net.Aws.AwsHttpConnection _connection;

        private readonly SearchContext conn;
        public PropsRepo(SearchContext esltSrch)
        {
            conn = esltSrch;
        }


        public Property property { get; set; }
        public Searcher searcher { get; set; }
        int? limits = new Searcher().limit;

        public async Task<IEnumerable<Property>> GetProperties(string searchPhrase)
        {
            searchPhrase = searcher.searchPhrase;
            var response = conn.Search<Property>(s => s
            .Index("propertyindex")
            .From(0)
            .Size(limits)
            .Query(q => q
            .Term(t => t.name, searchPhrase) || q
            .Match(mq => mq.Field(f => f.name).Query("*"))));



            return response.Documents;

            //return await _connection.RequestAsync.GetPropertiesAsync(requestData);
            //throw new System.NotImplementedException();
        }

        public Task<Property> GetProperty(string name)
        {
            name = searcher.searchPhrase;

            var response = conn.Search<Property>(s => s
               .Index("propertyindex")
               .From(0)
               .Size(limits)
               .Query(q => q
               .Term(t => t.name, name) || q
               .Match(mq => mq.Field(f => f.formerName).Query("*"))));



            return (Task<Property>)response.Documents;
        }

        public Task<Property> GetPropertyByCity(string CityName)
        {
            CityName = searcher.searchPhrase;

            var response = conn.Search<Property>(s => s
                  .Index("propertyindex")
                  .From(0)
                  .Size(limits)
                  .Query(q => q
                  .Term(t => t.city, CityName) || q
                  .Match(mq => mq.Field(f => f.state).Query("*"))));



            return (Task<Property>)response.Documents;
        }

        public Task<Property> GetPropertyByMarket(string Mrktname)
        {
            
            Mrktname = searcher.searchPhrase;

            var response = conn.Search<Property>(s => s
                  .Index("propertyindex")
                  .From(0)
                  .Size(limits)
                  .Query(q => q
                  .Term(t => t.market, Mrktname) || q
                  .Match(mq => mq.Field(f => f.market).Query("*"))));



            return (Task<Property>)response.Documents;
        }

        public Task<Property> GetPropertyByState(string state)
        {
            state = searcher.searchPhrase;
            var response = conn.Search<Property>(s => s
                 .Index("propertyindex")
                 .From(0)
                 .Size(limits)
                 .Query(q => q
                 .Term(t => t.state, state) || q
                 .Match(mq => mq.Field(f => f.city).Query("*"))));
            return (Task<Property>)response.Documents;
        }
    }
}
