using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MusicApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Song>? Songs { get; set; }
    }
}
