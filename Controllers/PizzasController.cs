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
            return Ok(PizzasServices.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            if(id <= 0) return BadRequest();
            Pizza p = PizzasServices.GetById(id);
            if(p == null) return NotFound();
            else return Ok(p);
        }

        [HttpPost]
        public IActionResult Create(Pizza p){
            bool cambios = PizzasServices.Create(p);
            if(!cambios) return BadRequest();
            else return CreatedAtAction(nameof(Create), new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza p){
            if(p.Id != id) return BadRequest();
            bool cambios = PizzasServices.Update(id,p);
            if(!cambios) return NotFound();
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            if(id <= 0) return BadRequest();
            bool cambios = PizzasServices.Delete(id);
            if(!cambios) return NotFound();
            return Ok();
        }
    }
}
