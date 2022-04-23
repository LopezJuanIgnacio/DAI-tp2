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
    public class Usuario{
        public int Id {get; set;}
        public string Nombre {get; set;} = "";
        public string Apellido {get; set;} = "";
        public string UserName {get; set;} = "";
        public string PassWord {get; set;} = "";
        public string Token {get; set;} = "";
        public DateTime TokenExpirationDate {get; set;} = DateTime.Now;
    }
}