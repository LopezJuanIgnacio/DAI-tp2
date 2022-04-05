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

namespace TP1.Helpers{
    public static class SecurityHelper{
        public static bool IsValidToken(string token){
            Usuario p = null;
            p = UsuariosServices.GetTokenById(token);
            if(p != null) return true;
            return false;
        }
    }
}