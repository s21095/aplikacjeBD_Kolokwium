using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models.DTO
{
    public class SearchingAlbum
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<SearchingTrack> Tracks { get; set; }
    }
}
