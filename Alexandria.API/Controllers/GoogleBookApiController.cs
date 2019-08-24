using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Service;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Web;

namespace Alexandria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleBookApiController : ControllerBase
    {

        [HttpGet("getbookfromapi")]
        public async Task<IActionResult> GetBookFromApi([FromBody]ISBNDTO isbn)
        {         
            try
            {
                var result = await SearchISBN(isbn);

                if ( result != null) 
                    return  Ok(result);
                else
                    return StatusCode(412);
            }
            catch (Exception e)
            {
                return Ok(SearchISBN(isbn));
            }
        }

        public static async Task<Volume> SearchISBN(ISBNDTO isbn)
        {
            var result = await service.Volumes.List(JsonConvert.ToString(isbn)).ExecuteAsync();
            if (result != null && result != null)
            {
                var item = result.Items.FirstOrDefault();
                return item;
            }
            return null;
        }


        public static BooksService service = new BooksService(
              new BaseClientService.Initializer
              {
                  ApplicationName = "Alexandria",
                  ApiKey = "AIzaSyDoCsVU8-fuGdvUgPQrpMD9YSyET5th-70",
              });

             
    }
}