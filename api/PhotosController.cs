using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WGwebapp.BusinessLogic;
using WGwebapp.Models;

namespace WGwebapp.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpGet]
        [Route("{date}")]
        public async Task<List<PhotoViewModel>> GetImages(DateTime date)
        {
            WatchGuardMarsRover wgmr = new WatchGuardMarsRover();
            return await wgmr.GetPhotos(date);
        }
    }
}

