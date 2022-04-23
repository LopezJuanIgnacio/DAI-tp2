using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Dapper;
using TP1.Utils;
using System.Text.Json;
using TP1.Models;

namespace TP1.Services{
    public static class PizzasServices{
        public static List <Pizza> GetAll(){
            try
            {
                List <Pizza> p = null;
                using (SqlConnection db = BD.GetConnection())
                {
                    p = db.Query<Pizza>("SELECT * FROM Pizzas").ToList();
                }
                return p;
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                throw;
            }
        }
        public static Pizza GetById(int id){
            try
            {
                Pizza p = null;
                using (SqlConnection db = BD.GetConnection())
                {
                    p = db.QueryFirstOrDefault<Pizza>("SELECT * FROM Pizzas WHERE @Pid = Id", new {Pid = id});
                }
                return p;
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                throw;
            }
        }
        public static int Create(Pizza p){
            try
            {
                int a = 0;
                using (SqlConnection db = BD.GetConnection())
                {
                    a = db.Execute("INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) VALUES (@Pnombre, @Plg, @Pimporte, @Pdescripcion) SELECT CAST(SCOPE_IDENTITY() AS INT);", new {Pnombre = p.Nombre, Plg = p.LibreGluten, Pimporte = p.Importe, Pdescripcion = p.Descripcion});
                }
                return a;
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                throw;
            }
        }
        public static bool Update(int id, Pizza p){
            try
            {
                int a = 0;
                using (SqlConnection db = BD.GetConnection())
                {
                    a = db.Execute("UPDATE Pizzas SET Nombre = @Pnombre, LibreGluten = @Plg, Importe = @Pimporte, Descripcion = @Pdescripcion WHERE @Pid = Id", new {Pid = p.Id, Pnombre = p.Nombre, Plg = p.LibreGluten, Pimporte = p.Importe, Pdescripcion = p.Descripcion});
                }
                if(a > 0) return true;
                return false;
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                throw;
            }
        }
        public static bool Delete(int id){
            try
            {
                int a = 0;
                using (SqlConnection db = BD.GetConnection())
                {
                    a = db.Execute("DELETE FROM Pizzas WHERE Id = @Pid", new {Pid = id});
                }
                if(a > 0) return true;
                return false;
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                throw;
            }
        }
    }
}