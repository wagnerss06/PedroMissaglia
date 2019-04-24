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

    public class BookController : ControllerBase
    {
        [HttpPost("insertbook")]
        public IActionResult InsertBook([FromBody]Book book)
        {

            try
            {
                BookService bookservice = new BookService();

                bookservice.AddBook(book);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("listbook/{n}")]
        public IActionResult ListBook( [FromRoute] int n)
        {
            try
            {
                BookService bookservice = new BookService();

                return Ok(bookservice.GetListBook(n));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("getbookisbn")]
        public IActionResult GetBookIsbn([FromBody]ISBNDTO item)
        {
            try
            {
                BookService bookservice = new BookService();

                return Ok(bookservice.GetBookIsbn(item.isbn));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("getbookisbn13")]
        public IActionResult GetBookIsbn13([FromBody]ISBN13DTO item)
        {
            try
            {
                BookService bookservice = new BookService();

                return Ok(bookservice.GetBookIsbn13(item.isbn13));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("getbookauthor")]
        public IActionResult GetBookFromAuthor([FromBody]AuthorNameDTO item)
        {
            try
            {
                BookService bookservice = new BookService();

                return Ok(bookservice.GetBookAuthor(item.Author));
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}

