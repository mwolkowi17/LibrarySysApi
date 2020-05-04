using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySysApi.Models;

namespace LibrarySysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCsController : ControllerBase
    {
        private readonly LibrarySysApiContext _context;

        public BookCsController(LibrarySysApiContext context)
        {
            _context = context;
        }

        // GET: api/BookCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookC>>> GetBookC()
        {
            return await _context.BookC.ToListAsync();
        }

        // GET: api/BookCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookC>> GetBookC(int id)
        {
            var bookC = await _context.BookC.FindAsync(id);

            if (bookC == null)
            {
                return NotFound();
            }

            return bookC;
        }

        // PUT: api/BookCs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookC(int id, BookC bookC)
        {
            if (id != bookC.BookCID)
            {
                return BadRequest();
            }

            _context.Entry(bookC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookCs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookC>> PostBookC(BookC bookC)
        {
            _context.BookC.Add(bookC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookC", new { id = bookC.BookCID }, bookC);
        }

        // DELETE: api/BookCs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookC>> DeleteBookC(int id)
        {
            var bookC = await _context.BookC.FindAsync(id);
            if (bookC == null)
            {
                return NotFound();
            }

            _context.BookC.Remove(bookC);
            await _context.SaveChangesAsync();

            return bookC;
        }

        private bool BookCExists(int id)
        {
            return _context.BookC.Any(e => e.BookCID == id);
        }
    }
}
