﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                if (userservice.Login(user.Email, user.Password))
                    return Ok();

                return NotFound();
            }
            catch (Exception e)
            {

                throw e;
            }


        }
        [HttpPost("signup")]
        public IActionResult SignUpUser([FromBody]User user) {

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

    }
}