using BackendBookMannu.Data;
using BackendBookMannu.Models;
using BackendBookMannu.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBookMannu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByID([FromRoute] int id)
        {
            var book = await _bookService.GetBookById(id);
            return CreatedAtAction("GetBookByID", new { Id = book?.Id }, book);
        }

        // GET: api/Books/by-category/{id}
        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetBooksByCategoryId([FromRoute] int id)
        {
            var books = await _bookService.GetBooksByCategoryId(id);
            return Ok(books);
        }

        // GET: api/Books/by-title?title=
        [HttpGet("by-title")]
        public async Task<IActionResult> GetBooksByTitle([FromQuery] string title)
        {
            var result = await _bookService.GetBooksByTitle(title);
            if (result == null || !result.Any()) return NotFound($"No books found with the specified title '{title}'");
            return Ok(result);
        }
    }
}
