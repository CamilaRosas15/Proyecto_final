using MyPlayList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayList.Data
{
    public class InMemoryCancionesData : ICancionesData
    {
        private readonly List<Cancion> canciones;
        
        public InMemoryCancionesData()
        {
            canciones = new List<Cancion>()
            {
                new Cancion { Id = 1, Title = "hello",ArtistName = "Adele", Duration = 3,genero = TipoDeGenero.Pop},
                new Cancion { Id = 2, Title = "Tarot", ArtistName="Bad Bunny", Duration= 3, genero= TipoDeGenero.Latino},
                new Cancion { Id= 3, Title= "Bachata", ArtistName= "Manuel Turizo", Duration = 3, genero = TipoDeGenero.Bachata }
            };
        }
        public IEnumerable<Cancion> GetAll()
        {
            return from s in canciones
                   orderby s.Title
                   select s;
           
        }
    }
}
