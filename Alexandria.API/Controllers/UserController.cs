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
                var usu = userservice.Login(user.Email, user.Password);

                IdDTO usuId = new IdDTO(usu.Id);

                

                //Caso achar retorna 200 e o usuario
                if (usu != null)
                    return Ok(usuId);
                else
                {
                    //caso nao busca somente por email
                    usu = userservice.Login(user.Email);
                    if (usu != null)
                        //se achar retorna 422
                        return StatusCode(412);
                    else
                        //caso contrario retorna 412
                        return StatusCode(422);
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

                return Ok();
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


    }
}