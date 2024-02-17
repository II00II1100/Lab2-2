using AutoMapper;
using LibApp.Data;
using LibApp.Models;
using LibApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LibApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Include(b => b.Genre)
                .ToList()
                .Select(_mapper.Map<Book, BookDto>);
            return Ok(books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = _mapper.Map<BookDto>(_context.Books.SingleOrDefault(b => b.Id == id));

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Books.Add(_mapper.Map<Book>(bookDto));
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetBook), new { id = bookDto.Id });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            _mapper.Map(bookDto, bookInDb);

            _context.SaveChanges();
            return Ok(bookInDb);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }
            _context.Remove(bookInDb);
            _context.SaveChanges();

            return Ok(bookInDb);
        }


        private ApplicationDbContext _context;
        private IMapper _mapper;
    }

}