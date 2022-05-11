using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class PuestoController : Controller
    {
        public IActionResult GetAll()
        {
            Negocio.Puesto puesto = new Negocio.Puesto();
            Negocio.Result result = Negocio.Puesto.GetAll();
            if (result.Correct)
            {
                puesto.Puestos = result.Objects;
                return View(puesto);
            }
            return PartialView("ValidationModal");
        }
    }
}