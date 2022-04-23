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
using TP1.Helpers;

namespace TP1.Utils{
    public static class BD{
       public static SqlConnection GetConnection(){
           return new SqlConnection(ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings:ConnectionString"));
       }
    }
}