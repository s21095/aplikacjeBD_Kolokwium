using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     class AlbumsController : ControllerBase
    {
        private readonly IDbService _dBservice;
        public AlbumsController(IDbService dbservice)
        {
            _dBservice = dbservice;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            if (id == null)
            {
                return BadRequest("Provide a valid ID");
            }
                var album = await _dBservice.GetAlbum(id);
            return Ok(album);
        }

    }
}
