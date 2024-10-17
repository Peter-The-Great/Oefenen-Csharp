using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hoorcollege4._2.Models;
using Hoorcollege4._2.DTOs;

namespace Hoorcollege4._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MyContext _context = new MyContext();

        // GET: api/Movie (DTO)
        [HttpGet("Dto")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetDtoMovies()
        {
            var movies = await _context.Movies.Select(mov =>
                new MovieDto(mov.Id, mov.Title, mov.Year, mov.DirectorId)).ToListAsync();

            if (movies.Count < 1)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        
        // GET: api/Movie (No DTO)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.Include(m => m.Director).ToListAsync();

            if (movies.Count < 1)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        // GET: api/Movie/5 (DTO)
        [HttpGet("Dto/{id}")]
        public async Task<ActionResult<MovieDto>> GetDtoMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = new MovieDto(movie.Id, movie.Title, movie.Year, movie.DirectorId);
            
            return movieDto;
        }
        
        // GET: api/Movie/5 (No DTO)
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (movie == null)
            {
                return NotFound();
            }
            
            return movie;
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            var movie = new Movie(movieDto.Title, movieDto.Year, movieDto.DirectorId);
            movie.Id = id;

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movies.Any(e => e.Id == id))
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

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieDto movieDto)
        {
            var movie = new Movie(movieDto.Title, movieDto.Year, movieDto.DirectorId);
            
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
