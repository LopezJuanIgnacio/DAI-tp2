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

namespace TP1.Helpers{
    public static class SecurityHelper{
        public static bool IsValidToken(string token){
            Pizza p = null;
            using (SqlConnection db = BD.GetConnection())
            {
                p = db.QueryFirstOrDefault<Pizza>("SELECT * FROM Usuarios WHERE Token IS NOT NULL AND DATEDIFF(mi,TokenExpirationDate,GETDATE()) < 15", new {Pid = id});
            }
            if(p != null) return true;
            return false;
        }
    }
}