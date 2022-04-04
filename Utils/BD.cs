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
        public static List <Pizza> GetAll(){
            List <Pizza> p = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                p = db.Query<Pizza>("SELECT * FROM Pizzas").ToList();
            }
            return p;
        }
        public static Pizza GetById(int id){
            Pizza p = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                p = db.QueryFirstOrDefault<Pizza>("SELECT * FROM Pizzas WHERE @Pid = Id", new {Pid = id});
            }
            return p;
        }
        public static bool Create(Pizza p){
            int a = 0;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                a = db.Execute("INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) VALUES (@Pnombre, @Plg, @Pimporte, @Pdescripcion);", new {Pnombre = p.Nombre, Plg = p.LibreGluten, Pimporte = p.Importe, Pdescripcion = p.Descripcion});
            }
            if(a > 0) return true;
            return false;
        }
        public static bool Update(int id, Pizza p){
            int a = 0;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                a = db.Execute("UPDATE Pizzas SET Nombre = @Pnombre, LibreGluten = @Plg, Importe = @Pimporte, Descripcion = @Pdescripcion WHERE @Pid = Id", new {Pid = p.Id, Pnombre = p.Nombre, Plg = p.LibreGluten, Pimporte = p.Importe, Pdescripcion = p.Descripcion});
            }
            if(a > 0) return true;
            return false;
        }
        public static bool Delete(int id){
            int a = 0;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                a = db.Execute("DELETE FROM Pizzas WHERE Id = @Pid", new {Pid = id});
            }
            if(a > 0) return true;
            return false;
        }
    }
}