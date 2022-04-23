using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions; 
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
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
        }

        [HttpPost] 
        [Route("login")] 
        public IActionResult Login(Usuario usuario){
            try{
                Usuario p = UsuariosServices.Login(usuario.UserName, usuario.PassWord);
                if(p == null) return NotFound();
                else return Ok(p);
            }
            catch (SystemException ex)
            {
                /*context.MethodDescriptor.Hub.Name,
                context.MethodDescriptor.Name,*/
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
