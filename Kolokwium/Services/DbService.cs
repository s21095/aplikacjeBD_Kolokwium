using Kolokwium.Models;
using Kolokwium.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<SearchingAlbum>> IDbService.GetAlbum(int id)
        {
            return await _dbContext.Album.Where(e => e.IdAlbum == id)
                .Select(x => new SearchingAlbum
                {
                AlbumName = x.AlbumName,
                PublishDate = x.PublishDate,
                    Tracks = x.Tracks.Select(e => new SearchingTrack
                    {
                        TrackName = e.TrackName,
                        Duration = e.Duration

                    })
                }).ToListAsync();
        }
    }
}
