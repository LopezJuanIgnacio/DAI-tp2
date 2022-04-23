using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http.Extensions; 
using Dapper;
using TP1.Utils;
using TP1.Models;
using TP1.Services;
using TP1.Helpers;

namespace TP1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly ILogger<PizzasController> _logger;

        public PizzasController(ILogger<PizzasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(){
            try
            {
                return Ok(PizzasServices.GetAll());
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                return Problem("Hubo un - Internal Server Error!!", 
                    HttpContext.Request.GetDisplayUrl(),
                    StatusCodes.Status500InternalServerError, 
                    "Surgió un Error", 
                    "Http://www.problemas-resolver.com/error-delete" 
                );
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            try
            {
                if(id == 31)throw new ArgumentException("prueba");
                if(id <= 0) return BadRequest();
                Pizza p = PizzasServices.GetById(id);
                if(p == null) return NotFound();
                else return Ok(p);
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                return Problem("Hubo un - Internal Server Error!!", 
                    HttpContext.Request.GetDisplayUrl(),
                    StatusCodes.Status500InternalServerError, 
                    "Surgió un Error", 
                    "Http://www.problemas-resolver.com/error-delete" 
                );
            }
        }

        [HttpPost]
        public IActionResult Create(Pizza p){
            try
            {
                string headerToken = Request.Headers["token"];
                if(!SecurityHelper.IsValidToken(headerToken)) return Unauthorized();
                int cambios = PizzasServices.Create(p);
                if(cambios <= 0) return BadRequest();
                else return CreatedAtAction(nameof(Create), new { id = p.Id }, p);
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                return Problem("Hubo un - Internal Server Error!!", 
                    HttpContext.Request.GetDisplayUrl(),
                    StatusCodes.Status500InternalServerError, 
                    "Surgió un Error", 
                    "Http://www.problemas-resolver.com/error-delete" 
                );
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza p){
            try
            {
                string headerToken = Request.Headers["token"];
                if(!SecurityHelper.IsValidToken(headerToken)) return Unauthorized();
                if(p.Id != id) return BadRequest();
                bool cambios = PizzasServices.Update(id,p);
                if(!cambios) return NotFound();
                return Ok(p);
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                return Problem("Hubo un - Internal Server Error!!", 
                    HttpContext.Request.GetDisplayUrl(),
                    StatusCodes.Status500InternalServerError, 
                    "Surgió un Error", 
                    "Http://www.problemas-resolver.com/error-delete" 
                );
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try
            {
                string headerToken = Request.Headers["token"];
                if(!SecurityHelper.IsValidToken(headerToken)) return Unauthorized();
                if(id <= 0) return BadRequest();
                bool cambios = PizzasServices.Delete(id);
                if(!cambios) return NotFound();
                return Ok();
            }
            catch (SystemException ex)
            {
                CustomLog.LogError(ex);
                return Problem("Hubo un - Internal Server Error!!", 
                    HttpContext.Request.GetDisplayUrl(),
                    StatusCodes.Status500InternalServerError, 
                    "Surgió un Error", 
                    "Http://www.problemas-resolver.com/error-delete" 
                );
            }
        }
    }
}
