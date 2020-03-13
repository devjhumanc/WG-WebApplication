using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WGwebapp.Models
{
    public class PhotoViewModel
    {
        public int PhotoId { get; set; }
        public DateTime EarthDate { get; set; }
        public string ImageSrc { get; set; }
    }
}
