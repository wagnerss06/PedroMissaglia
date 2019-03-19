using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Alexandria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult LoginAsCommonUser([FromBody]UserDTO user)
        {           
            try
            {
                UserService userservice = new UserService();

                object[] varCond = userservice.Login(user.Email, user.Password);

                if (varCond[0].ToString() == "1")
                    
                    return Ok(JsonConvert.SerializeObject(varCond[1]));

                else if (varCond[0].ToString() == "2")

                    return StatusCode(412);
                else
                    return StatusCode(422);
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        [HttpPost("signup")]
        public IActionResult SignUpUser([FromBody]User user)
        {

            try
            {
                UserService userservice = new UserService();

                userservice.AddUser(user);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //Em andamento
        [HttpGet("delete")]
        public IActionResult DeleteUser([FromBody]User user)
        {
            try
            {
                UserService userservice = new UserService();

                userservice.RemoveUser(user);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Request post para envio de e-mail para troca de senha
        [HttpPost("forgotPassword")]
        public IActionResult SendEmail([FromBody]EmailDTO Email)
        {
            try
            {
                UserService userservice = new UserService();

                userservice.Email(Email.Email);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("newPassword")]
        public IActionResult NewPassword([FromBody]NewPasswordDTO item)
        {
            try
            {
                UserService userservice = new UserService();

                userservice.UpdateUser(item);
          

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}