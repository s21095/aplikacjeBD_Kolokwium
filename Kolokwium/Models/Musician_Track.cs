using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }


        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}
