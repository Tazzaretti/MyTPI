
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using MyTest.Common;
using Service.Iservices;
using System.Security.Claims;
namespace MyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly IUserSerivice _userSerivice;
        private readonly ILogger<UserController> _logger;
        public UserController (IUserSerivice adminService, ILogger<UserController> logger)
        {
            _userSerivice = adminService;
            _logger = logger;
        }
        
        [HttpGet("getUserById/{id}")]
        public ActionResult<UserDTO> getUserById([FromRoute]int id) {

            try
            {
                var response = _userSerivice.getUserById(id);
                if (response == null)
                {
                    return NotFound($"No se encontro el usuario con id {id}");
                }
                return Ok(response);    
            
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("getUserByID", ex);
                return BadRequest($"{ex.Message}");
            }

        }
        
        
        

        [HttpGet ("getAll")]
        public ActionResult<List<UserDTO>> getAll()
        {

            try
            {
                var response = _userSerivice.getAll();
                if (response.Count == 0) {
                    return NotFound("No hay Usuarios");
                }
                return Ok(response);
                    }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetEmpleadoById", ex);
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete ("DeleteUsers/{id}")]
        public ActionResult DeleteUsers(int id)
        {
            try {
                _userSerivice.DeleteUsers(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
