﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public  class Empresa
    {


        public int? IdEmpresa { get; set; }
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string DireccionWeb { get; set; }

        public List<Object> Empresas { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsValidExcel { get; set; }


    }
}
