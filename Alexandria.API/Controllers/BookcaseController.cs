using System;
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
    public class BookcaseController : ControllerBase
    {

        [HttpPost("insertbookinbookcase")]
        public IActionResult InsertBook([FromBody]UserBookcaseDTO userbookcase )
        {
            object eir;
            Guid idbookcase;
            try
            {
                BookcaseService bookcaseservice = new BookcaseService();

                //Caso já possua bookcase
                if (bookcaseservice.questionExistenciality(userbookcase.Id))
                {
                    bookcaseservice.CreateBookcase(userbookcase);
                }
                //Caso não, cria uma com o livro recebido por parâmetro e insere ela no user 
                else
                {
                    idbookcase = bookcaseservice.CreateBookcase(userbookcase);
                      bookcaseservice.UpdateUserWithBookcase(userbookcase.Id, idbookcase);
                }
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}