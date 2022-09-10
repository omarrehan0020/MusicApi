using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public float Duration { get; set; }

        public DateTime UploadedDate { get; set; }

        public bool IsFeatured { get; set; }

     


    }
}
