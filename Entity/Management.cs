﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPISMART
{
    public class Management 
    {
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
    }
}
