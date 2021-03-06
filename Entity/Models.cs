using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPISMART.Entity
{
    public class Models
    {

        public class Searcher
        {
            [Required]
            public string searchPhrase { get; set; }
            [MaxLength(25)]
            public int? limit;

        }


        public class Property
        {
            public int propertyID { get; set; }
            public string name { get; set; }
            public string formerName { get; set; }
            public string city { get; set; }
            public string market { get; set; }
            public string state { get; set; }
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Management
        {
            public int mgmtID { get; set; }
            public string name { get; set; }
            public string market { get; set; }
            public string state { get; set; }
        }
    }
}
