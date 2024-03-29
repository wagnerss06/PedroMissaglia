﻿using System;
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
        public IActionResult SignUpUser([FromBody]Avatar avatar)
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



    }
}

