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

    public class AuthorsController : ControllerBase
    {
        [HttpPost("insert")]
        public IActionResult InsertAuthors([FromBody]Authors authors)
        {

            try
            {
                AuthorsService authorsservice = new AuthorsService();

                authorsservice.AddAuthors(authors);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("listauth")]
        public IActionResult ListAuthors()
        {
            try
            {
                AuthorsService authorsservice = new AuthorsService();

                return Ok(authorsservice.GetListAut());
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}