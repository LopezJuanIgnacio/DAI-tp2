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

namespace TP1.Services{
    public static class UsuariosServices{
        public static Usuario Login(string userName, string password){
            Usuario p = null;
            p = GetByUserNamePassword(userName, password);
            if(p != null) {
                p.Token = RefreshToken(p.Id);
                return p;
            }
            else return null;
        }
        public static Usuario GetByUserNamePassword(string userName, string password){
            Usuario p = null;
            using (SqlConnection db = BD.GetConnection())
            {
                p = db.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE userName = @u AND password = @p ", new {u = userName, p = password});
            }
            return p;
        }
        public static Usuario GetTokenById(string token){
            Usuario p = null;
            using (SqlConnection db = BD.GetConnection())
            {
                p = db.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Token = @t AND DATEDIFF(mi,TokenExpirationDate,GETDATE()) < 15", new {t = token});
            }
            return p;
        }
        //podria ser private
        public static string RefreshToken(int id){
            string nuevoToken = Guid.NewGuid().ToString();
            DateTime expiracion = DateTime.Now;
            int t = 0;
            using (SqlConnection db = BD.GetConnection())
            {
                t = db.Execute("UPDATE Usuarios SET Token = @t, TokenExpirationDate = @e WHERE id = @Tid;", new {t = nuevoToken, e = expiracion, Tid = id});
            }
            if(t > 0) return nuevoToken;
            return null;
        }
    }
}