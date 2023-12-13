using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayList.Core
{
    public class Cancion
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? ArtistName { get; set; }

        public double Duration { get; set; }
        public TipoDeGenero genero { get; set; }
    }
}


