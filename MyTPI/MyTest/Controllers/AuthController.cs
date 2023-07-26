﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.ViewModels;
using MyTest.Common;
using Service.Iservices;
using Service.Service;
namespace MyTest.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] AuthDTO User)
        {
            string response = string.Empty;
            try
            {
                response = _service.Login(User);
                if (string.IsNullOrEmpty(response))
                    return NotFound("email/contraseña incorrecta");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Login", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }

        [HttpPost("CrearUsuario")]
        public ActionResult<string> CrearUsuario([FromBody] UserViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.CrearUsuario(User);
                if (response == "Ingrese un usuario" || response == "Usuario existente")
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("CrearUsuario", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }
    }
      
}

