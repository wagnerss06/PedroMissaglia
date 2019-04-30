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
                
                //Busca usuario por email e senha
                var usu = userservice.Login(user.Email);
                object use = null;
                

                IdDTO usuId = new IdDTO(usu.Id);

                //Caso achar retorna 200 e o usuario
                if (usu != null)
                {

                    use = userservice.Login(user.Email, user.Password);
                    if (use != null)
                        return Ok(usuId);

                    else { return StatusCode(412); }
                }
                else
                {


                    return StatusCode(422);
                    //caso contrario retorna 412

                }
                
                    
                
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

                var usu = userservice.GetUserEmail(user.Email);


                //Caso achar retorna 200 e o usuario
                if (usu != null)
                {
                    IdDTO usuId = new IdDTO(usu.Id);
                    return Ok(usuId);
                }
                else
                {
                    return StatusCode(422);
                    //caso contrario retorna 412
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //Em andamento
        [HttpDelete("delete")]
        public IActionResult DeleteUser([FromBody]IdDTO user)
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

                userservice.UpdatePasswordUser(item);
          

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("newuseravatar")]
        public IActionResult UpdateUserAvatar([FromBody]UserAvatarDTO item)
        {
            try
            {
                UserService userservice = new UserService();

                userservice.UpdateAvatarUser(item);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("getuser/{userid}")]
        public IActionResult GetUser([FromRoute]Guid userid)
        {
            try
            {
                UserService userservice = new UserService();

                //Busca usuario por id
                var usu = userservice.GetUser(userid);

                //Caso achar retorna 200 e o usuario
                if (usu != null)
                    return Ok(usu);
                else
                {
                   return StatusCode(412);
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }



    }
}