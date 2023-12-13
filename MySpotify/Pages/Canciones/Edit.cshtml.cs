using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPlayList.Data;
using MyPlayList.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MySpotify.Pages.Canciones
{
    public class EditModel : PageModel
    {
        private readonly ICancionesData cancionesData;

        private readonly IHtmlHelper htmlHerper;

        public IEnumerable<SelectListItem> Generos { get; set; }
        
        [BindProperty]
        public Cancion Cancion { get; set; }

        public EditModel(ICancionesData cancionesData,IHtmlHelper htmlHelper)
        {
            this.cancionesData = cancionesData;
            this.htmlHerper = htmlHelper;
        }
        public IActionResult OnGet(int? cancionesId)
        {
            Generos = htmlHerper.GetEnumSelectList<TipoDeGenero>();

            if(cancionesId.HasValue)
            {
                Cancion = cancionesData.GetById(cancionesId.Value);
            }
            else
            {
                Cancion = new Cancion();
            }
            if(Cancion == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost() 
        { 
            //No ACTUALIZA
            if (!ModelState.IsValid)
            {
                Generos = htmlHerper.GetEnumSelectList<TipoDeGenero>();
                return Page();
            }

            if ( Cancion.Id > 0)
            {
                cancionesData.Update(Cancion);
            }
            else
            {
                //
            }
            cancionesData.Commit();
            TempData["Message"] = "Cancion Guardadas!";
            return RedirectToPage("./Detail", new { cancionesId = Cancion.Id });
        }
    }
}
