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
                new Cancion { Id = 1, Title = "hello",ArtistName = "Adele", Duration = 5,genero = TipoDeGenero.Pop},
                new Cancion { Id = 2, Title = "Tarot", ArtistName="Bad Bunny", Duration= 3, genero= TipoDeGenero.Latino},
                new Cancion { Id= 3, Title= "Bachata", ArtistName= "Manuel Turizo", Duration = 4.20, genero = TipoDeGenero.Bachata}
            };
        }
        public IEnumerable<Cancion> GetAll()
        {
            return from s in canciones
                   orderby s.Title
                   select s; 
        }
        public Cancion GetById(int id)
        {
            //return canciones.SingleOrDefault(s => s.Id == id);
            return canciones.Find(s => s.Id == id);
        }

        public Cancion Update(Cancion updateCancion)
        {
            //var cancion = canciones.SingleOrDefault(s => s.Id == updateCancion.Id);
            var cancion = canciones.Find(s => s.Id == updateCancion.Id);

            if (cancion != null)
            {
                cancion.Title = updateCancion.Title;
                cancion.ArtistName = updateCancion.ArtistName;
                cancion.Duration = updateCancion.Duration;
                cancion.genero = updateCancion.genero;
            }
            return cancion;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
