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
using System.Text.Json;
using TP1.Helpers;

namespace TP1.Utils{
    public static class CustomLog{
       public static void LogError (Exception ex){
           String data = DateTime.Now + ex.ToString();
           String LogFolder = ConfigurationHelper.GetConfiguration().GetValue<string>("CustomLog:LogFolder") + "\\errores.txt";
           IOHelper.AppendInFile(LogFolder,data);
       }
       public static void LogError (string errorData){
           String LogFolder = ConfigurationHelper.GetConfiguration().GetValue<string>("CustomLog:LogFolder") + "\\errores.txt";
           IOHelper.AppendInFile(LogFolder,errorData);
       }
       public static void LogError (Exception ex, object datos){
           String data = DateTime.Now + ex.ToString() + datos.ToString();
           String LogFolder = ConfigurationHelper.GetConfiguration().GetValue<string>("CustomLog:LogFolder") + "\\errores.txt";
           IOHelper.AppendInFile(LogFolder,data);
       }
       public static void LogError (string errorData, object datos){
           String data = DateTime.Now + errorData + datos.ToString();
           String LogFolder = ConfigurationHelper.GetConfiguration().GetValue<string>("CustomLog:LogFolder") + "\\errores.txt";
           IOHelper.AppendInFile(LogFolder,data);
       }
    }
}