using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _context;
        public ArtistsController()
        {
            _context = new ApiDbContext();
        }
        // GET: api/<ArtistsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var Artists = _context.Artists;

            return Ok(Artists);
           
        }

        // GET api/<ArtistsController>/5
        [HttpGet("[action]/{id}")]
        public IActionResult ArtistDetails(int id)
        {
             Artist artist =  _context.Artists.Include(x => x.Songs).SingleOrDefault(x => x.Id == id);
            return Ok(artist);
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
