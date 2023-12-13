using MyPlayList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayList.Data
{
    public interface ICancionesData
    {
        IEnumerable<Cancion> GetAll();

        Cancion GetById(int id);
        //funcion edit
        Cancion Update(Cancion updateCancion);

        int Commit();
    }
}
