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
using TP1.Services;
using Microsoft.Extensions.Configuration;

namespace TP1.Helpers{
    public static class ConfigurationHelper{
        public static IConfiguration GetConfiguration () {
            IConfiguration config;
            var builder = new ConfigurationBuilder() 
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange:true); 
            config = builder.Build(); 
            return config; 
        }
    }
}