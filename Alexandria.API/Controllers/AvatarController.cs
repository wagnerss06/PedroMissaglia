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

    public class AvatarController : ControllerBase
    {
        [HttpPost("insert")]
        public IActionResult InsertAvatar([FromBody]Avatar avatar)
        {

            try
            {
                AvatarService avatarservice = new AvatarService();

                avatarservice.AddAvatar(avatar);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("list")]
        public IActionResult ListAvatar()
        {
           try
            {
                AvatarService avatarservice = new AvatarService();

                return Ok(avatarservice.GetListAvatar());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("getavatar/{avatarid}")]
        public IActionResult GetAvatar([FromRoute]Guid avatarid)
        {
            try
            {
                AvatarService avatarservice = new AvatarService();

                //Busca usuario por id
                var usu = avatarservice.GetAvatar(avatarid);

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

