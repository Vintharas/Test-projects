using System.Collections.Generic;

namespace MvcMusicStore.Models
{
    public class Genre
    {
        public virtual string GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}