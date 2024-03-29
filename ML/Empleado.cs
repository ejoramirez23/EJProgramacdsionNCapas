﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {

        public string NumeroEmpleado { get; set; }

        public string Nombre { get; set; }


        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

       

        public string RFC { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }



        public string NSS { get; set; }

        public string FechaNacimiento { get; set; }

        public string FechaIngreso { get; set; }



        public List<Object> Empleados { get; set; }

        public byte[] Foto { get; set; }

        public ML.Empresa Empresa { get; set; }

        public ML.Dependiente Dependiente { get; set; }

    }
}
