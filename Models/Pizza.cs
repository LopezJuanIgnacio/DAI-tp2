using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Dapper;
using TP1.Utils;

namespace TP1.Models{
    public class Pizza{
        public int Id {get; set;}
        public string Nombre {get; set;}
        public bool LibreGluten {get; set;}
        public float Importe {get; set;}
        public string Descripcion {get; set;}
    }
}