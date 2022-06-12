using Kolokwium.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    interface IDbService
    {
        Task<IEnumerable<SearchingAlbum>> GetAlbum(int id);
    }
}
