using MyPlayList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyPlayList.Data;
using System.Data.SqlTypes;

namespace MySpotify.Pages.Canciones
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICancionesData cancionesData;

        public string? Message { get; set; }
        public IEnumerable<Cancion> Canciones{ get; set; }
        public ListModel(IConfiguration config, ICancionesData cancionesData)
        {
            this.config = config;
            this.cancionesData = cancionesData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Canciones = cancionesData.GetAll();
        }
    }
}
