using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Dapper;
using TP1.Utils;
using TP1.Models;

namespace TP1.Utils{
    public static class BD{
        private static string _connectionString = @"Server=DESKTOP-D44S535\SQLEXPRESS;DataBase=DAI-Pizzas;Trusted_Connection=True";
       public static SqlConnection GetConnection(){
           return new SqlConnection(_connectionString);
       }
    }
}