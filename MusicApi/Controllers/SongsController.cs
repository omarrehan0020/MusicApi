using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _context;
        public SongsController()
        {
            _context = new ApiDbContext();
        }
        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Songs =  _context.Songs;
            return Ok(Songs);
        }
        [HttpGet("[action]")]
        public IActionResult SongsFeaturd()
        {
            var Songs = _context.Songs.Where(x => x.IsFeatured);
            return Ok(Songs);
        }
        [HttpGet("[action]")]
        public IActionResult NewSongs()
        {
            var Songs = _context.Songs.OrderBy(x => x.UploadedDate).Take(3);
            return Ok(Songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("[action]/{query}")]
        public async Task<IActionResult> SearchSong(string query)
        {
            var Songs =  _context.Songs.Where(x => x.Title.StartsWith(query));
            return Ok(Songs);
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song  song)
        {
            song.UploadedDate = DateTime.Now;
            _context.Songs.Add(song);
            _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

    }
}
