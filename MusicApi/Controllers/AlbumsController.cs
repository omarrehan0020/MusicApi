using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using System.Data.Entity;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private ApiDbContext _context;
        public AlbumsController()
        {
            _context = new ApiDbContext();
        }
        // GET: api/<AlbumsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var Albums = _context.Albums;

            return Ok(Albums);

        }

        // GET api/<ArtistsController>/5
        [HttpGet("[action]/{id}")]
        public IActionResult AlbumDetails(int id)
        {
            Album Album = _context.Albums.Include(x => x.Songs).SingleOrDefault(x => x.Id == id);
            return Ok(Album);
        }

        // POST api/<AlbumsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<AlbumsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
