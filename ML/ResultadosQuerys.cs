﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ResultadosQuerys
    {
        public bool Correct { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        public Exception Ex { get; set; }


        //public int IdentityGet { get; set; }


    }
}
